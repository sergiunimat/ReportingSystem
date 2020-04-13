using Bloggy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloggy.ViewModels
{
    public class BlogPostListViewModel
    {
        public int TotalEntries { get; set; }
        public IEnumerable<BlogPost> BlogPosts { get; set; }
    }
}
