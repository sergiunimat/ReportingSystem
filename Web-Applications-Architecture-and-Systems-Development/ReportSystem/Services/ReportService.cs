using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReportSystem.Data;
using ReportSystem.Interfaces;
using ReportSystem.Models;

namespace ReportSystem.Services
{
    public class ReportService: IReportService
    {
        private readonly RoleManager<IdentityRole> _roleMancager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _ctx;

        public ReportService(RoleManager<IdentityRole> roleMancager, UserManager<ApplicationUser> userManager, ApplicationDbContext ctx)
        {
            _roleMancager = roleMancager;
            _userManager = userManager;
            _ctx = ctx;
        }

        public async Task CreateReport(Report report)
        {
            await _ctx.Reports.AddAsync(report);
            await _ctx.SaveChangesAsync();
        }

        public List<Report> GetAllReports()
        {
            return  _ctx.Reports.ToList();
        }

        public List<Report> GetReportsByReporterId(string userId)
        {
            return  _ctx.Reports.Where(r => r.ReportReporterId == userId).ToList();
        }

        public List<Report> GetReportsByInvestigatorId(string userId)
        {
            return _ctx.Reports.Where(r => r.ReportInvestigatorId == userId).ToList();
        }

        public Report GetReportById(int reportId)
        {
            return _ctx.Reports.FirstOrDefault(r => r.ReportId == reportId);
        }

        public async Task EditReport(Report report)
        {
            _ctx.Reports.Update(report);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteReportId(int reportId)
        {
            var delRep = await _ctx.Reports.FirstOrDefaultAsync(r => r.ReportId == reportId);
            _ctx.Remove(delRep);
            await _ctx.SaveChangesAsync();
        }

        public List<string> GetTopFiveReporters()
        {
            return _ctx.Reports.GroupBy(r => r.ReportReporterId).OrderBy(rp => rp.Count()).Take(5).Select(r => r.Key)
                .ToList();
        }


    }
}
