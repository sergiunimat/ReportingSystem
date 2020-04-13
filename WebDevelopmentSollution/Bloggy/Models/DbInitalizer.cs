using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloggy.Models
{
    public class DbInitalizer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.BlogPosts.Any())
            {
                context.AddRange(
                    new BlogPost()
                    {
                        Title = "High alert - don't panic",
                        Content = "Everything's fine..",
                        CreatedDate = DateTime.Today,
                        ImageUrl = "/images/seed1.jpg"
                    },
                    new BlogPost()
                    {
                        Title = "Everything is normal",
                        Content = "Lorem ipsum",
                        CreatedDate = DateTime.Today.AddDays(-1),
                        ImageUrl = "/images/seed2.jpg"
                    },
                    new BlogPost()
                    {
                        Title = "Let it shine",
                        Content = "The sun is our friend.",
                        CreatedDate = DateTime.Today.AddDays(-3),
                        ImageUrl = "/images/seed3.jpg"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
