using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReportSystem.Interfaces;
using ReportSystem.Models;
using ReportSystem.ViewModels;

namespace ReportSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IReportService _reportService;
        private readonly IHazardService _hazardService;
        private readonly ICommentService _commentService;


        public HomeController(
                                ILogger<HomeController> logger,
                                RoleManager<IdentityRole> roleManager,
                                UserManager<ApplicationUser> userManager,
                                IReportService reportService,
                                IHazardService hazardService,
                                ICommentService commentService
                                )
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
            _reportService = reportService;
            _hazardService = hazardService;
            _commentService = commentService;
        }

        
        public IActionResult Index()
        {
            var listofReports = _reportService.GetAllReports();
            if (listofReports.Count!=0)
            {
                var listDto = new List<ReportViewModel>();
                foreach (var report in listofReports)
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

            return NotFound();
            //return User != null && User.Identity.IsAuthenticated
            //    ? (IActionResult) RedirectToAction("LogedInIndex", "Home", new {userId = _userManager.GetUserId(User)})
            //    : View();
        }
        [Authorize]
        public IActionResult LogedInIndex(string userId)
        {
            return View("Index");
        }
        [Authorize]
        public IActionResult Manager()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
