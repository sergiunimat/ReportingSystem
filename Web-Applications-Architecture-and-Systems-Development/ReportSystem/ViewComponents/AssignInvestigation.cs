using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReportSystem.Interfaces;
using ReportSystem.Models;
using ReportSystem.ViewModels;

namespace ReportSystem.ViewComponents
{
    public class AssignInvestigation : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IReportService _reportService;

        public AssignInvestigation(UserManager<ApplicationUser> userManager, IReportService reportService)
        {
            _userManager = userManager;
            _reportService = reportService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int reportId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var report = _reportService.GetReportById(reportId);

            var investigation = new InvestigationViewModel()
            {
                ReportId = report.ReportId,
                ReportTitle = report.ReportTitle,
                InvestigatorId = user.Id,
                InvestigatorName = user.UserName,
                InvestigatorEmail = user.Email,
            };
            return View(investigation);
        }
    }
}
