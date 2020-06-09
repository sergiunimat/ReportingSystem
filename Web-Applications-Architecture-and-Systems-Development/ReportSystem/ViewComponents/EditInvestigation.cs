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
    public class EditInvestigation: ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IReportService _reportService;
        private readonly IInvestigationService _investigationService;

        public EditInvestigation(UserManager<ApplicationUser> userManager, IReportService reportService,IInvestigationService investigationService)
        {
            _userManager = userManager;
            _reportService = reportService;
            _investigationService = investigationService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int investigationId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var tempInv = _investigationService.GetInvestigationById(investigationId);
            var report = _reportService.GetReportById(tempInv.ReportId);

            var investigation = new InvestigationViewModel()
            {
                ReportId = report.ReportId,
                InvestigationId = tempInv.InvestigationId,
                ReportTitle = report.ReportTitle,
                InvestigatorId = user.Id,
                InvestigatorName = user.UserName,
                InvestigatorEmail = user.Email,
                InvestigationDescription = tempInv.InvestigationDescription,
                InvestigationStatus = report.ReportStatus
            };
            return View(investigation);
        }
    }
}
