using Bloggy.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bloggy
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public IConfiguration _configuration { get; }

        //Requeting injection of a IWebHostEnvironment object (Provides information about the web hosting environment an application is running in).
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            //Setting this to a private var for use in ConfigureServices
            _env = env;
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //These environments are specified via the ASPNETCORE_ENVIRONMENT variable (see Properties/launchSettngs.json)
            if (_env.IsDevelopment())
                services.AddTransient<IBlogPostRepository, BlogPostRepository>();
            //if (_env.IsEnvironment("Test")) 
            //    services.AddTransient<IBlogPostRepository, MockBlogPostRepository>();
            //if (_env.IsProduction())
            //    services.AddTransient<IBlogPostRepository, MockBlogPostRepository>(); //This will be an actual repo
            
            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
