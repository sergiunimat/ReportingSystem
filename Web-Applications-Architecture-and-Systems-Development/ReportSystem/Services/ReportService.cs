using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
    }
}
