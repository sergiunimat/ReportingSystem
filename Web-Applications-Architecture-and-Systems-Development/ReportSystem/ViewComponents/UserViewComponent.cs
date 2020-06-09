using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReportSystem.Interfaces;
using ReportSystem.Models;
using ReportSystem.ViewModels;

namespace ReportSystem.ViewComponents
{
    public class UserViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IReportService _reportService;
        private readonly IInvestigationService _investigationService;
        private readonly ICommentService _commentService;
        private readonly ILikeService _likeService;

        public UserViewComponent(UserManager<ApplicationUser> userManager, IReportService reportService, IInvestigationService investigationService,ICommentService commentService, ILikeService likeService)
        {
            _userManager = userManager;
            _reportService = reportService;
            _investigationService = investigationService;
            _commentService = commentService;
            _likeService = likeService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            var user= await _userManager.FindByIdAsync(userId);
            var currUser = await _userManager.GetUserAsync(HttpContext.User);
            string currentUserId;
            currentUserId = currUser == null ? "" : currUser.Id;
            var viewModel = new UserViewModel()
            {
                UserId =user.Id,
                CurrentUserId = currentUserId,
                UserName = user.UserName,
                UserAddress = user.UserAddress,
                UserEmail = user.Email,
                UserReportCount = _reportService.GetReportsByReporterId(user.Id).Count,
                UserInvestigationCount = _investigationService.GetInvestigationsByReporterId(user.Id).Count,
                UserCommentCount = _commentService.GetAllCommentsByReporterId(user.Id).Count,
                UserLikeCount = _likeService.GetAllLikesByReporterId(user.Id).Count
            };
            return View(viewModel);
        }
    }
}
