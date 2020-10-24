using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotNetApp.Application1.Interfaces;
using DotNetApp.Application1.Services;
using DotNetApp.Core.Interface;

//using DotNetApp.Application.Interfaces;
//using DotNetApp.Application.Services;
using DotNetApp.Core.Repositories;
using DotNetApp.Core.Repositories.Base;
using DotNetApp.Infrastructure.Data;
using DotNetApp.Infrastructure.Logging;
using DotNetApp.Infrastructure.Repository;
using DotNetApp.Infrastructure.Repository.Base;
using DotNetApp.Web.Interface;
using DotNetApp.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DotNetApp.web
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

            //// use real database
            services.AddDbContext<DotNetAppContext>(c =>
            c.UseSqlServer(Configuration.GetConnectionString("AspnetRunConnection"), x => x.MigrationsAssembly("DotNetApp.Web")));
            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddDefaultUI()
            //    .AddEntityFrameworkStores<DotNetAppContext>();
            //          services.AddIdentity <IdentityUser, IdentityRole()
            //.AddDefaultUI()
            //.AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultTokenProviders();

            //          //password of user
            //          services.Configure<IdentityOptions>(options =>
            //          {
            //              // Password settings.
            //              options.Password.RequireDigit = false;
            //              options.Password.RequireLowercase = false;
            //              options.Password.RequireNonAlphanumeric = false;
            //              options.Password.RequireUppercase = false;
            //              options.Password.RequiredLength = 6;
            //              options.Password.RequiredUniqueChars = 1;
            //          });



            // Add ASP.NET Identity support
            services.AddIdentity<IdentityUser, IdentityRole>(
                opts =>
                {
                    opts.Password.RequireDigit = true;
                    opts.Password.RequireLowercase = true;
                    opts.Password.RequireUppercase = true;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequiredLength = 7;
                })
                .AddEntityFrameworkStores<DotNetAppContext>();



            // aspnetrun dependencies
            ConfigureAspnetRunServices(services);



            services.AddControllersWithViews();


        
        }

        private void ConfigureAspnetRunServices(IServiceCollection services)
        {
            //generic repository(implemented generic method)(typeof)

            //infrastucture
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            //Application
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            //Web
            services.AddScoped<IIndexPageService, IndexPageService>();
            services.AddScoped<ICategoryPageService, CategoryPageService>();

            //core
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            services.AddAutoMapper(typeof(Startup));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
