using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReportSystem.Interfaces;
using ReportSystem.Models;
using ReportSystem.ViewModels;

namespace ReportSystem.Controllers
{
    public class ReportController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IReportService _reportService;

        public ReportController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,IHostingEnvironment hostingEnvironment,IReportService reportService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _hostingEnvironment = hostingEnvironment;
            _reportService = reportService;
        }
        public async Task<IActionResult> Index()
        {
           
            return View();

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CreateReport()
        {
           
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateReportAsync(ReportViewModel reportViewModel)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (reportViewModel.ReportPicture!=null)
                {
                    string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + reportViewModel.ReportPicture.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    reportViewModel.ReportPicture.CopyTo(new FileStream(filePath,FileMode.Create));
                }
                var report = new Report()
                {
                    ReportTitle = reportViewModel.ReportTitle,
                    ReportPicturePath = uniqueFileName,
                    ReportDescription = reportViewModel.ReportDescription,
                    ReportLatitude = reportViewModel.ReportLatitude,
                    ReportLongitude = reportViewModel.ReportLongitude,
                    ReportReporterId = user.Id,
                    ReportStatus = false
                    
                };
                await _reportService.CreateReport(report);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("CreateReport", reportViewModel);
            }
        }
    }
}