﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReportSystem.Interfaces;
using ReportSystem.Models;
using ReportSystem.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReportSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;
        private readonly IAdminService _adminService;
        private readonly IEmailService _emailService;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUserService userService,IAdminService adminService,IEmailService emailService )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _adminService = adminService;
            _emailService = emailService;
        }
        /*I: this controller deals with different account facilities.*/
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.Name,
                    Email = model.Email,
                    UserAddress = model.Address,
                    EmailConfirmed = true
                };
               
               var result = await _userManager.CreateAsync(user, model.Password);
               await _userManager.AddToRoleAsync(user, Role.Reporter);
                if (result.Succeeded)
                {
                    ///*I: generate email confirmation token*/
                    //var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    ///*I: build confirmation link*/
                    //var emailConfirmationLink = Url.Action("ConfirmMail", "Account",
                    //    new { userId = user.Id, token = token }, Request.Scheme);

                    /*we are sign in the user with a session cookie i.e. when browser is closed the cookie is destroyed*/
                    await _signInManager.SignInAsync(user,isPersistent:false);
                    _emailService.SendEmail(user.Email,"Welcome",EmailBodyContent.Welcome);
                   return RedirectToAction("Index", "Home");
                }

                foreach (var err in result.Errors)
                {
                    /*I: this will display all the errors in the Register view in the div with the attr asp-validation-summary="All"*/
                    ModelState.AddModelError("",err.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                /*This is necessary since the userName and email are different and just by using model.Email it will throw an error
                    this way we are getting the username and fetch it in the fist parameter.*/

                //var signedUser = _userManager.FindByEmailAsync(model.Email);

                /*something is bad here since the we do not succeed.*/
                var result = await _signInManager.PasswordSignInAsync(model.Name, model.Password,isPersistent:model.RememberMe,false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.Name);
                    var role = await _userManager.GetRolesAsync(user);
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        // check if user has admin role
                        return role.Contains(Role.Administrator) ? RedirectToAction("Index", "Admin", new { userId = user.Id })
                                                                    : RedirectToAction("Index", "Home",new{userId=user.Id});
                    }
                    
                }
                ModelState.AddModelError("", "We are sorry, something went wrong while logging in.");
            }
            return View(model);
        }

        public IActionResult ConfirmMail(string userid, string token)
        {
            return View();
        }

        public IActionResult PasswordRecovery()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UserViewModel user)
        {
            var editUser= new ApplicationUser()
            {
                Id = user.UserId,
                UserName = user.UserName,
                Email = user.UserEmail,
                UserAddress= user.UserAddress
            };
            //await _userManager.UpdateAsync(editUser);
           await _userService.EditUser(editUser);
            
            return RedirectToAction("Index", "Home");
        }

        /*I: this Action result is called from all AJAX request when editing/vieweing a user*/
        public async Task<IActionResult> EditUserRedirect(string userId)
        {
            return ViewComponent("User", new { userId = userId });

        }
    }
}
