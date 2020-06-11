using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReportSystem.Data;
using ReportSystem.Interfaces;
using ReportSystem.Models;
using ReportSystem.ViewModels;

namespace ReportSystem.Services
{
    public class AdminService :IAdminService
    {
        private readonly RoleManager<IdentityRole> _roleMancager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _ctx;
        private readonly IUserService _userService;

        public AdminService(RoleManager<IdentityRole> roleMancager, UserManager<ApplicationUser> userManager, ApplicationDbContext ctx, IUserService userService)
        {
            _roleMancager = roleMancager;
            _userManager = userManager;
            _ctx = ctx;
            _userService = userService;
        }
        public async Task EditUser(EditUserViewModel userObj)
        {
            //var user = _userManager.Users.FirstOrDefaultAsync(x => x.Id == userObj.UserId);
            var user = await _userManager.FindByIdAsync(userObj.UserId);
            if (userObj.InvestigatorRole==true)
            {
                await _userManager.AddToRoleAsync(user, Role.Investigator);
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user,Role.Investigator);
            }
            if (userObj.AdminRole == true)
            {
                await _userManager.AddToRoleAsync(user, Role.Administrator);
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, Role.Administrator);
            }
            if (user!=null)
            {
                user.Email = userObj.UserEmail;
                user.UserName = userObj.UserName;
                _ctx.Users.Update(user);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                _ctx.Users.Remove(user);
                await _ctx.SaveChangesAsync();
            }
        }

        public void DelUser(string userId)
        {
            var user = _ctx.Users.FirstOrDefault(u => u.Id == userId);
            if (user!=null)
            {
                _ctx.Users.Remove(user);
                _ctx.SaveChanges();
            }
        }
    }
}
