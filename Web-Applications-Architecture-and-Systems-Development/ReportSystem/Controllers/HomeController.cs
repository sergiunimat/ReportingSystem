using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReportSystem.Models;

namespace ReportSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;


        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        
        public IActionResult Index()
        {
            return User != null && User.Identity.IsAuthenticated
                ? (IActionResult) RedirectToAction("LogedInIndex", "Home", new {userId = _userManager.GetUserId(User)})
                : View();
        }
        [Authorize]
        public IActionResult LogedInIndex(string userId)
        {
            return View("Index");
        }
        [Authorize]
        public IActionResult Manager()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
