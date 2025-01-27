﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReportSystem.Interfaces;
using ReportSystem.Models;
using ReportSystem.ViewModels;

namespace ReportSystem.Controllers
{
    [Authorize(Roles = Role.Administrator)]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAdminService _adminService;
        private readonly IReportService _reportService;
        private readonly IInvestigationService _investigationService;

        public AdminController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAdminService adminService, IReportService reportService, IInvestigationService investigationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _adminService = adminService;
            _reportService = reportService;
            _investigationService = investigationService;
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
            return ViewComponent("EditUser", new{userId=userId});
        }
        [HttpPost]
        public async Task<IActionResult> EditUserAsync(EditUserViewModel formDTO)
        {
            await _adminService.EditUser(formDTO);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var u= await _userManager.FindByIdAsync(userId);
            var inv = _investigationService.CheckIfInvestigatorIsActive(u.Id);
            var rep = _reportService.GetReportsByReporterId(u.Id).Count;
            if (!inv && rep==0)
            {
                await _adminService.DeleteUser(userId);
                return RedirectToAction("Users");
            }
            return RedirectToAction("Users");
        }
    }
}