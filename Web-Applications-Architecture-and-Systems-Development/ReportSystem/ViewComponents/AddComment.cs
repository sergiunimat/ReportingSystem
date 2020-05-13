using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReportSystem.Interfaces;
using ReportSystem.ViewModels;

namespace ReportSystem.ViewComponents
{
    public class AddComment: ViewComponent
    {
        private readonly IReportService _reportService;

        public AddComment(IReportService reportService)
        {
            _reportService = reportService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int reportId)
        {
            var report = _reportService.GetReportById(reportId);
            var comment = new CommentViewModel()
            {
                ReportId = report.ReportId
            };
            return View(comment);
        }
    }
}
