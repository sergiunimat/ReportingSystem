using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReportSystem.Models;
using ReportSystem.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReportSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
                    UserName = model.Email,
                    Email = model.Email,
                    UserAddress = model.City
                };
               
               var result = await _userManager.CreateAsync(user, model.Password);
               await _userManager.AddToRoleAsync(user, Role.Reporter);
                if (result.Succeeded)
               {
                   /*we are sign in the user with a session cookie i.e. when browser is closed the cookie is destroyed*/
                   await _signInManager.SignInAsync(user,isPersistent:false);
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
                var signedUser = _userManager.FindByEmailAsync(model.Email);
                /*something is bad here since the we do not succeed.*/
                var result = await _signInManager.PasswordSignInAsync(signedUser.Result.UserName, model.Password,isPersistent:model.RememberMe,false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    
                }
                ModelState.AddModelError("", "We are sorry, something went wrong while logging in.");
            }
            return View(model);
        }
    }
}
