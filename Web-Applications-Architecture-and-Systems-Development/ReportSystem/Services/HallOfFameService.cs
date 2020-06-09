using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ReportSystem.Data;
using ReportSystem.Interfaces;
using ReportSystem.Models;
using ReportSystem.ViewModels;

namespace ReportSystem.Services
{
    public class HallOfFameService: IHallOfFameService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _ctx;
        private readonly IReportService _reportService;
        private readonly IInvestigationService _investigationService;
        private readonly ICommentService _commentService;
        private readonly ILikeService _likeService;

        public HallOfFameService(UserManager<ApplicationUser> userManager,
            ApplicationDbContext ctx,IReportService reportService,
            IInvestigationService investigationService,
            ICommentService commentService,
            ILikeService likeService
            )
        {
            _userManager = userManager;
            _ctx = ctx;
            _reportService = reportService;
            _investigationService = investigationService;
            _commentService = commentService;
            _likeService = likeService;
        }

        public List<BestReporterViewModel> GetBestReporters()
        {
            var users = _userManager.Users;
            var reports = _reportService.GetAllReports();
            var returnList = new List<BestReporterViewModel>();
            foreach (var user in users)
            {
                var t = new BestReporterViewModel()
                {
                    ReporterName = user.UserName,
                    ReportsNumber = 0
                };
                foreach (var report in reports)
                {
                    if (report.ReportReporterId==user.Id)
                    {
                        t.ReportsNumber++;
                    }
                }
                returnList.Add(t);
            }
            return returnList;
        }

        public List<BestInvestigator> GetBestInvestigators()
        {
            var users = _userManager.Users;
            var investigations = _investigationService.GetAllInvestigations();
            var returnList = new List<BestInvestigator>();
            foreach (var user in users)
            {
                var t = new BestInvestigator()
                {
                    InvestigatorName = user.UserName,
                    InvestigationNumber = 0
                };
                foreach (var investigation in investigations)
                {
                    if (investigation.InvestigatorId == user.Id)
                    {
                        t.InvestigationNumber++;
                    }
                }
                returnList.Add(t);
            }
            return returnList;
        }

        public List<ReportWithMostComments> GetReportWithMostComments()
        {
            var reports = _reportService.GetAllReports();
            var returnList = new List<ReportWithMostComments>();
            foreach (var report in reports)
            {
                var t = new ReportWithMostComments()
                {
                    ReportTitle = report.ReportTitle,
                    ReportComments = _commentService.GetAllCommentsByReportId(report.ReportId).Count
                };
                returnList.Add(t);
            }
            return returnList;
        }

        public List<ReportWithMostLikes> GetReportWithMostLikes()
        {
            var reports = _reportService.GetAllReports();
            var returnList = new List<ReportWithMostLikes>();
            foreach (var report in reports)
            {
                var t = new ReportWithMostLikes()
                {
                    ReportTitle = report.ReportTitle,
                    ReportLikes = _likeService.GetAlLikesForReport(report.ReportId).Count
                };
                returnList.Add(t);
            }
            return returnList;
        }
    }
}
