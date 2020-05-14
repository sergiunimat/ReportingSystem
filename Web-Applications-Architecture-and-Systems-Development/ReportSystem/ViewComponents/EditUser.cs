using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReportSystem.Models;
using ReportSystem.ViewModels;

namespace ReportSystem.ViewComponents
{
    public class EditUser:ViewComponent
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public EditUser(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            var userToEdit = await _userManager.FindByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(userToEdit);
            var modelDTO = new EditUserViewModel()
            {
                UserName = userToEdit.UserName,
                UserId = userToEdit.Id,
                UserEmail = userToEdit.Email,
                AdminRole = await _userManager.IsInRoleAsync(userToEdit,Role.Administrator),
                InvestigatorRole = await _userManager.IsInRoleAsync(userToEdit,Role.Investigator),
                ReporterRole = await _userManager.IsInRoleAsync(userToEdit,Role.Reporter),
            };
            return View(modelDTO);
        }
    }
}
