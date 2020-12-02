using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using DotNetApp.Application1.Interfaces;
using DotNetApp.Application1.Mapper;
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
//using DotNetApp.Web.Servicess;
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
           
         // services.AddAutoMapper(Assembly.GetAssembly(typeof(Startup)));
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
            services.AddScoped<IProductPageService, ProductPageService>();

            //core
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            // services.AddAutoMapper();// Add AutoMapper
            // services.AddAutoMapper(c => c.AddProfile<AspnetRunProfileApplication>(), typeof(Startup));

            services.AddAutoMapper(typeof(Startup)); // Add AutoMapper

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
