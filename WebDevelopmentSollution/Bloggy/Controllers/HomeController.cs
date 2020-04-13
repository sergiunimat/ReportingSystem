using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bloggy.Models;
using Bloggy.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public HomeController(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Blog Index View";
            
            var model = new BlogPostListViewModel();
            model.BlogPosts = _blogPostRepository.GetAllBlogPosts().OrderByDescending(p => p.CreatedDate);
            model.TotalEntries = model.BlogPosts.Count();

            return View(model);
        }
    }
}