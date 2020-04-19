using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReportSystem.Models;

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
            return View(userToEdit);
        }
    }
}
