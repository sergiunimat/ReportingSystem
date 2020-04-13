using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloggy.Models
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly AppDbContext _appDbContext;

        public BlogPostRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<BlogPost> GetAllBlogPosts()
        {
            return _appDbContext.BlogPosts;
        }

        public BlogPost GetBlogPostById(int blogPostId)
        {
            return _appDbContext.BlogPosts.FirstOrDefault(p => p.Id == blogPostId);
        }
    }
}
