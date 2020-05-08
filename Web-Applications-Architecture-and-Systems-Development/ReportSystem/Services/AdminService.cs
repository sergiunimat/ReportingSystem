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
    public class AdminService :IAdminService
    {
        private readonly RoleManager<IdentityRole> _roleMancager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _ctx;

        public AdminService(RoleManager<IdentityRole> roleMancager, UserManager<ApplicationUser> userManager, ApplicationDbContext ctx)
        {
            _roleMancager = roleMancager;
            _userManager = userManager;
            _ctx = ctx;
        }
        public async Task EditUser(EditUserObject userObj)
        {
            //var user = _userManager.Users.FirstOrDefaultAsync(x => x.Id == userObj.UserId);
            var user = await _userManager.FindByIdAsync(userObj.UserId);
            if (user!=null)
            {
                user.Email = userObj.UserEmail;
                user.UserName = userObj.UserName;
                _ctx.Users.Update(user);
                _ctx.SaveChanges();
            }
        }
    }
}
