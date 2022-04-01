using Books.Bl;
using EvaraStore.Bl;
using EvaraStore.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaraStore
{
    public class Startup
    {
        IConfiguration config;
        public Startup(IConfiguration configuration)
        {
            config = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
            services.AddControllersWithViews();

            // Use ConnectionString Of Database SqlServer
            services.AddDbContext<EvaraStoreContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            // Use Dependency Injection
            services.AddScoped<IItemService, ClsItems>();
            services.AddScoped<ICategoryService, ClsCategories>();
            services.AddScoped<ISubCategoryService, ClsSubCategories>();
            services.AddScoped<IBillingService, ClsBilling>();
            services.AddScoped<IRateService, ClsRate>();
            services.AddScoped<IOrderService, ClsOrder>();
            services.AddScoped<IOrderItemsService, ClsOrderItems>();
            services.AddScoped<ISettingService, ClsSetting>();

            services.AddCloudscribePagination();

            services.AddIdentity<AppUser, IdentityRole>(option =>
             {
                 option.Password.RequiredLength = 8;
                 option.Password.RequireNonAlphanumeric = false;
                 option.Password.RequireUppercase = true;
                 option.User.RequireUniqueEmail = true;

             }).AddEntityFrameworkStores<EvaraStoreContext>();
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.Name = "Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(24);
                options.LoginPath = "/Users/Login";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
