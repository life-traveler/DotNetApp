using DotNetApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace DotNetApp.Infrastructure.Data
{
    //implement user class
    //custom and inbuilt
    //inbuilt
    public class DotNetAppContext : IdentityDbContext<IdentityUser>

    {
        public DotNetAppContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }



        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }


        //creating table which is collecting all entities THROUGH MODEL
        //SO THE NMAE IN DATABASE WILL BE PRODUCT AND NOT PRODUCTS
        private static void SetTableNamesAsSingle(ModelBuilder builder)
        {
            // Use the entity name instead of the Context.DbSet<T> name
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                builder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            SetTableNamesAsSingle(builder);

            base.OnModelCreating(builder); //

        }
    }
}
