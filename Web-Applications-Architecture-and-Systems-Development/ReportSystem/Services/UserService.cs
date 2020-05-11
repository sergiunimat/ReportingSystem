using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ReportSystem.Interfaces;
using ReportSystem.Models;

namespace ReportSystem.Services
{
    public class UserService : IUserService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
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

    }
}
