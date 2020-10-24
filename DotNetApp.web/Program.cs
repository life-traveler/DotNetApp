using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetApp.Infrastructure.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotNetApp.web
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            SeedDatabase(host);

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        private static void SeedDatabase(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    //provide the instance of teh context class to data seeder
                    var aspnetRunContext = services.GetRequiredService<DotNetAppContext>();

                    //var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    //var userManager = services.GetRequiredService<UserManager<IdentityUser
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

                    // Create the Db if it doesn't exist and applies any pending migration.
                    //dbContext.Database.Migrate();

                    IdentitySeeder.Seed(aspnetRunContext, roleManager, userManager);




                    //craete the admin and other users
                    //IdentitySeeder.Seed(aspnetRunContext, roleManager, userManager);
                    //DataSeeder.SeedAsync(aspnetRunContext, loggerFactory).Wait();

                }
                catch (Exception exception)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(exception, "An error occurred seeding the DB.");
                }
            }
        }






        //public static void Main(string[] args)
        //{
        //    CreateHostBuilder(args).Build().Run();
        //}

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
