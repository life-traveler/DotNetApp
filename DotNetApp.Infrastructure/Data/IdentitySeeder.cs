﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetApp.Infrastructure.Data
{
  public  class IdentitySeeder
    {
        #region Public Methods
        public static void Seed(
            DotNetAppContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager
            )
        {
            // Create default Users (if there are none)
            if (!dbContext.Users.Any())
            {
                CreateUsers(dbContext, roleManager, userManager)
                    .GetAwaiter()
                    .GetResult();
            }

            // Create default Quizzes (if there are none) together with their set of Q&A
           // if (!dbContext.Quizzes.Any()) CreateQuizzes(dbContext);
        }
        #endregion

        #region Seed Methods
        private static async Task CreateUsers(
            DotNetAppContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            // local variables
            DateTime createdDate = new DateTime(2016, 03, 01, 12, 30, 00);
            DateTime lastModifiedDate = DateTime.Now;

            //2 different roles(any number of roles)
            string role_Administrator = "Administrator";
            string role_RegisteredUser = "RegisteredUser";

            //Create Roles (if they doesn't exist yet)
            if (!await roleManager.RoleExistsAsync(role_Administrator))
            {
                await roleManager.CreateAsync(new IdentityRole(role_Administrator));
            }
            if (!await roleManager.RoleExistsAsync(role_RegisteredUser))
            {
                await roleManager.CreateAsync(new IdentityRole(role_RegisteredUser));
            }

            // Create the "Admin" ApplicationUser account
            var user_Admin = new IdentityUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Admin",
                Email = "admin@testmakerfree.com",
                //they were custom data (applicationUsrt)
                //CreatedDate = createdDate,
                //LastModifiedDate = lastModifiedDate
            };
            // Insert "Admin" into the Database and assign the "Administrator" and "Registered" roles to him.
            if (await userManager.FindByIdAsync(user_Admin.Id) == null)
            {
                //actual password(Pass$Admin)
                await userManager.CreateAsync(user_Admin, "Pass4Admin");
                // await userManager.AddToRoleAsync(user_Admin, role_RegisteredUser);
                //create the role that user is now admin
                await userManager.AddToRoleAsync(user_Admin, role_Administrator);
                // Remove Lockout and E-Mail confirmation.
                //
                user_Admin.EmailConfirmed = true;
                user_Admin.LockoutEnabled = false;
            }

#if DEBUG
            // Create some sample registered user accounts
            var user_Ryan = new IdentityUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Ryan",
                Email = "ryan@testmakerfree.com",
                //CreatedDate = createdDate,
                //LastModifiedDate = lastModifiedDate
            };

            var user_Solice = new IdentityUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Solice",
                Email = "solice@testmakerfree.com",
                //CreatedDate = createdDate,
                //LastModifiedDate = lastModifiedDate
            };

            var user_Vodan = new IdentityUser ()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Vodan",
                Email = "vodan@testmakerfree.com",
                //CreatedDate = createdDate,
                //LastModifiedDate = lastModifiedDate
            };

            // Insert sample registered users into the Database and also assign the "Registered" role to him.
            if (await userManager.FindByIdAsync(user_Ryan.Id) == null)
            {
                await userManager.CreateAsync(user_Ryan, "Pass4Ryan");
                await userManager.AddToRoleAsync(user_Ryan, role_RegisteredUser);
                // Remove Lockout and E-Mail confirmation.
                user_Ryan.EmailConfirmed = true;
                user_Ryan.LockoutEnabled = false;
            }
            if (await userManager.FindByIdAsync(user_Solice.Id) == null)
            {
                await userManager.CreateAsync(user_Solice, "Pass4Solice");
                await userManager.AddToRoleAsync(user_Solice, role_RegisteredUser);
                // Remove Lockout and E-Mail confirmation.
                user_Solice.EmailConfirmed = true;
                user_Solice.LockoutEnabled = false;
            }
            if (await userManager.FindByIdAsync(user_Vodan.Id) == null)
            {
                await userManager.CreateAsync(user_Vodan, "Pass4Vodan");
                await userManager.AddToRoleAsync(user_Vodan, role_RegisteredUser);
                // Remove Lockout and E-Mail confirmation.
                user_Vodan.EmailConfirmed = true;
                user_Vodan.LockoutEnabled = false;
            }

#endif
            await dbContext.SaveChangesAsync();
     
        }

        #endregion
    }
}
