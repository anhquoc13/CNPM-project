using Application.Interfaces;
using Application.Services;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Entities
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            ConfigureScoped(services);
            services.AddDbContext<FlashCardContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("Default")));
            
            services.AddAuthentication("Cookies")
                    .AddCookie();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureScoped(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IFolderRepository, FolderRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<ISignInManager, SignInManager>();
            services.AddScoped<ICourseServices, CourseServices>();
            services.AddScoped<IClassServices, ClassServices>();
            services.AddScoped<IFolderServices, FolderServices>();
        }
    }
}
