using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloggy.Models
{
    public class MockBlogPostRepository : IBlogPostRepository
    {
        private List<BlogPost> _posts;

        public MockBlogPostRepository()
        {
            if (_posts == null)
            {
                InitializeBlogPosts();
            }
        }

        public IEnumerable<BlogPost> GetAllBlogPosts()
        {
            return _posts;
        }

        public BlogPost GetBlogPostById(int blogPostId)
        {
            return _posts.FirstOrDefault(p => p.Id == blogPostId);
        }

        private void InitializeBlogPosts()
        {
            _posts = new List<BlogPost>()
            {
                new BlogPost()
                {
                    Id = 1,
                    Title = "High alert - don't panic",
                    Content = "Everything's fine..",
                    CreatedDate = DateTime.Today,
                    ImageUrl = "/images/seed1.jpg"
                },
                new BlogPost()
                {
                    Id = 2,
                    Title = "Everything is normal",
                    Content = "Lorem ipsum",
                    CreatedDate = DateTime.Today.AddDays(-1),
                    ImageUrl = "/images/seed2.jpg"
                },
                new BlogPost()
                {
                    Id = 3,
                    Title = "Let it shine",
                    Content = "The sun is our friend.",
                    CreatedDate = DateTime.Today.AddDays(-3),
                    ImageUrl = "/images/seed3.jpg"
                }
            };
        }
    }
}
