using System;
using System.Collections.Generic;
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
    [Authorize(Roles = Role.Investigator+","+Role.Administrator)]
    public class InvestigateController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IReportService _reportService;
        private readonly IHazardService _hazardService;

        public InvestigateController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IHostingEnvironment hostingEnvironment,
            IReportService reportService,
            IHazardService hazardService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _hostingEnvironment = hostingEnvironment;
            _reportService = reportService;
            _hazardService = hazardService;
        }
        public async Task<IActionResult> Index()
        {
            //we shall pass a list of reports together with the current user
            var listOfReports = _reportService.GetAllReports();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var pendingReports = new List<SpecificReportViewModel>();
            var activeReports = new List<SpecificReportViewModel>();

            
            foreach (var r in listOfReports)
            {
                /*I: if the report is pending - i.e. in this case an investigator can be assigned to a report ONLY in this case*/
                if (r.ReportStatus==0)
                {
                    var report = new SpecificReportViewModel()
                    {
                        ReportId = r.ReportId,
                        ReportDescription = r.ReportDescription,
                        ReportTitle = r.ReportTitle,
                        HazardTitle = _hazardService.GetHazardTitleById(r.ReportHazardId),
                        CurrentUserId = user.Id,
                        ReportRegisterTime = r.ReportRegisterTime,
                        ReporterName = _userManager.FindByIdAsync(r.ReportReporterId).Result.UserName,
                        ReporterId = r.ReportReporterId,
                        Status = r.ReportStatus,
                        //InvestigatorId = investigatroId,
                        //InvestigatorName = _userManager.FindByIdAsync(r.ReportInvestigatorId).Result.UserName
                    };
                    pendingReports.Add(report);
                }
                /*I: if the report is not pending i.e. anything else - an investigator is already assigned to the report*/
                else
                {
                    var report = new SpecificReportViewModel()
                    {
                        ReportId = r.ReportId,
                        ReportDescription = r.ReportDescription,
                        ReportTitle = r.ReportTitle,
                        HazardTitle = _hazardService.GetHazardTitleById(r.ReportHazardId),
                        CurrentUserId = user.Id,
                        ReportRegisterTime = r.ReportRegisterTime,
                        ReporterName = _userManager.FindByIdAsync(r.ReportReporterId).Result.UserName,
                        ReporterId = r.ReportReporterId,
                        Status = r.ReportStatus,
                        InvestigatorId = r.ReportInvestigatorId,
                        InvestigatorName = _userManager.FindByIdAsync(r.ReportInvestigatorId).Result.UserName
                    };
                    activeReports.Add(report);
                }
                
            }

            var Dto = new ActiveOrPendingReportsViewModel()
            {
                PendingReports = pendingReports,
                UnderInvestigationReports = activeReports
            };
            return View(Dto);
        }
    }
}