using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ReportSystem.Data;
using ReportSystem.Interfaces;
using ReportSystem.Models;
using ReportSystem.ViewModels;

namespace ReportSystem.Services
{
    public class UserService : IUserService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _ctx;

        public UserService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext ctx)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _ctx = ctx;
        }
        public async Task CreatePowerUserIfDoesNotExist()
        {
            var powerUser = _userManager.FindByEmailAsync("admin@mail.com").Result;
            if (powerUser == null)
            {
                var newPowerUser = new ApplicationUser()
                {
                    UserName = "Admin",
                    Email = "admin@mail.com",
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(newPowerUser, "admin");
                await _userManager.AddToRoleAsync(newPowerUser, Role.Administrator);
            }
        }

        public async Task EditUser(ApplicationUser model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.UserAddress = model.UserAddress;
                _ctx.Users.Update(user);
                await _ctx.SaveChangesAsync();
            }
           
        }

        public string GetUserEmail(ApplicationUser userId)
        {
            return _ctx.Users.FirstOrDefault(u => u.Id == userId.Id)?.Email;
        }

    }
}
