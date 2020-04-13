using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ReportSystem.Interfaces;
using ReportSystem.Models;

namespace ReportSystem.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task CreateRoleIfDoesNotExist(string roleName)
        {
            if (!_roleManager.RoleExistsAsync(roleName).Result)
            {
                IdentityRole identityRole = new IdentityRole()
                {
                    Name = roleName
                };
                await _roleManager.CreateAsync(identityRole);
            }
        }
    }
}
