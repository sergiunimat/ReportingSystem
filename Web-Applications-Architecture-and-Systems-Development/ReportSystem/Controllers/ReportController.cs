using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReportSystem.Interfaces;
using ReportSystem.Models;
using ReportSystem.ViewModels;

namespace ReportSystem.Controllers
{
    public class ReportController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IReportService _reportService;
        private readonly IHazardService _hazardService;
        private readonly ICommentService _commentService;

        public ReportController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IHostingEnvironment hostingEnvironment,
            IReportService reportService,
            IHazardService hazardService,
            ICommentService commentService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _hostingEnvironment = hostingEnvironment;
            _reportService = reportService;
            _hazardService = hazardService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> OwnReports()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var listOfOwnReports = _reportService.GetReportsByReporterId(user.Id);
            var listDto = new List<ReportViewModel>();
            foreach (var report in listOfOwnReports)
            {
                
                var r = new ReportViewModel()
                {
                    ReportId = report.ReportId,
                    ReportDescription = report.ReportDescription,
                    ReportTitle = report.ReportTitle,
                    PicturePath = report.ReportPicturePath,
                    ReportLatitude = report.ReportLatitude,
                    ReportLongitude = report.ReportLongitude,
                    HazardTitle = _hazardService.GetHazardTitleById(report.ReportHazardId),
                    ReportRegisterTime = report.ReportRegisterTime,
                    ReportCommentCount = _commentService.CountCommentsByReportId(report.ReportId),
                    ReporterName = _userManager.FindByIdAsync(report.ReportReporterId).Result.UserName
                };
                listDto.Add(r);

            }

            return View(listDto);
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CreateReport()
        {
            var hazardList = _hazardService.GetAllHazards();
            var sendModel = new ReportViewModel()
            {
                Hazards = hazardList
            };
            return View(sendModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateReport(ReportViewModel reportViewModel)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            await _hazardService.AddHazard(reportViewModel.HazardTitle);
            var hazardId = _hazardService.GetHazardIdByTitle(reportViewModel.HazardTitle);

            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (reportViewModel.ReportPicture != null)
                {
                    string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + reportViewModel.ReportPicture.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    reportViewModel.ReportPicture.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                var report = new Report()
                {
                    ReportTitle = reportViewModel.ReportTitle,
                    ReportPicturePath = uniqueFileName,
                    ReportDescription = reportViewModel.ReportDescription,
                    ReportLatitude = reportViewModel.ReportLatitude,
                    ReportLongitude = reportViewModel.ReportLongitude,
                    ReportReporterId = user.Id,
                    ReportStatus = false,
                    ReportHazardId = hazardId,
                    ReportRegisterTime = DateTime.Now

                };
                await _reportService.CreateReport(report);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("CreateReport", reportViewModel);
            }
        }

        public IActionResult EditReport(int reportId)
        {
            var report = _reportService.GetReportById(reportId);
            if (report != null)
            {
                //all the comments must be added to the report i.e. create a new viewmodel  
                return View();
            }

            //get report by id then create object and send it to the page
            return NotFound();
        }


        public async Task<IActionResult> ShowReport(int reportId)
        {
            var report = _reportService.GetReportById(reportId);
            var currentUser =  await _userManager.GetUserAsync(HttpContext.User);

            if (report != null)
            {
                var listOfCommentsForReport = _commentService.GetAllCommentsByReportId(reportId);
                var commentListDto = new List<CommentViewModel>();
                foreach (var c in listOfCommentsForReport)
                {
                    var commentUser = _userManager.FindByIdAsync(c.UserId).Result;
                    var commentDto = new CommentViewModel()
                    {
                        CommentCreateDate = c.CommentCreateDate,
                        CommentText = c.CommentText,
                        CommentOwner = commentUser.UserName,
                        UserId = commentUser.Id,
                        CommentId = c.CommentId

                        //ReportId = c.ReportId,
                        //CommentId = c.CommentId
                    };
                    commentListDto.Add(commentDto);
                }

                string currentUserId;
                currentUserId = currentUser==null ? "" : currentUser.Id;
                var currentReport = new SpecificReportViewModel()
                {
                    ReportId = report.ReportId,
                    ReportTitle = report.ReportTitle,
                    ReportDescription = report.ReportDescription,
                    HazardTitle = _hazardService.GetHazardTitleById(report.ReportHazardId),
                    PicturePath = report.ReportPicturePath,
                    ReportRegisterTime = report.ReportRegisterTime,
                    ReportLongitude = report.ReportLongitude,
                    ReportLatitude = report.ReportLatitude,
                    ReportCommentList = commentListDto,
                    CurrentUserId = currentUserId,
                    ReporterId = report.ReportReporterId,
                    ReporterName = _userManager.FindByIdAsync(report.ReportReporterId).Result.UserName,
                    //InvestigatorId = report.ReportInvestigatorId,
                    //InvestigatorName = _userManager.FindByIdAsync(report.ReportInvestigatorId).Result.UserName
                };
                return View(currentReport);
            }

            //get report by id then create object and send it to the page
            return NotFound();
        }
        [HttpGet]
        public IActionResult AddCommentRedirect(int reportId)
        {
            return ViewComponent("AddComment", new {reportId = reportId});
        }

        public async Task<IActionResult> AddComment(CommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                //get current user
                var user = await _userManager.GetUserAsync(HttpContext.User);
                //create comment
                _commentService.CreateComment(Guid.NewGuid(), comment.ReportId, user.Id, comment.CommentText);
                //retrieve comment
                return RedirectToAction("ShowReport", new{reportId=comment.ReportId});

            }

            return NotFound();
        }

        public async Task<IActionResult> DeleteReport(int reportId)
        {
            /*call the service*/
            await _reportService.DeleteReportById(reportId);

            return RedirectToAction("OwnReports");

        }
    }
}