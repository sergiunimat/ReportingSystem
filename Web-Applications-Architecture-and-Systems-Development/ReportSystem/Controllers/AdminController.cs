using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReportSystem.Models;

namespace ReportSystem.Controllers
{
    [Authorize(Roles = Role.Administrator)]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AdminController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            var userList = _userManager.Users;   
            return View(userList);
        }
        [HttpGet]
        public IActionResult EditUser(string userId)
        {
            var userList = _userManager.Users;
            return ViewComponent("EditUser",new{userId=userId});
        }

    }
}