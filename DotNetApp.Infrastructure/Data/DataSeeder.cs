using DotNetApp.Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetApp.Infrastructure.Data
{
    class DataSeeder
    {
        //fill all the databse table data
        //seedAsync : name of teh method to fill data

        public static async Task SeedAsync(DotNetAppContext aspnetrunContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            //context class  is virtual database
            try
            {
               await SeedCategoriesAsync(aspnetrunContext);
                await SeedReviewsAsync(aspnetrunContext);
                await SeedProductsAsync(aspnetrunContext);
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<DotNetAppContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync
                        (aspnetrunContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }



        //to check if the categories already have data then return that data , otherwise fill the category with new data
        private static async Task SeedCategoriesAsync(DotNetAppContext aspnetrunContext)
        {
            if (aspnetrunContext.Categories.Any())
                return;

            var categories = new List<Category>()
            {
                new Category() { Name = "Laptop"}, // 1
                new Category() { Name = "Drone"}, // 2
                  new Category() { Name = "TV & Audio"}, // 3
                new Category() { Name = "Phone & Tablet"}, // 4
                new Category() { Name = "Camera & Printer"}, // 5
                
                new Category() { Name = "Games"}, // 6
                new Category() { Name = "Accessories"}, // 7
                new Category() { Name = "Watch"}, // 8
                  new Category() { Name = "Home & Kitchen Appliances"} // 9
            };

            aspnetrunContext.Categories.AddRange(categories);
            await aspnetrunContext.SaveChangesAsync();

        }


        private static async Task SeedReviewsAsync(DotNetAppContext aspnetrunContext)
        {
            if (aspnetrunContext.Reviews.Any())
                return;

            var reviews = new List<Review>()
            {
                new Review
                {
                    Name = "Cristopher Lee",
                    EMail = "cristopher@lee.com",
                    Star = 4.3,
                    Comment = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia res eos qui ratione voluptatem sequi Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci veli"
                },

                new Review
                {
                    Name = "Nirob Khan",
                    EMail = "nirob@lee.com",
                    Star = 4.3,
                    Comment = "enim ipsam voluptatem  quia voluptas sit aspernatur aut odit aut fugit, sed quia res eos qui ratione voluptatem sequi Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci veli"
                },
                 new Review
                {
                    Name = "MD.ZENAUL ISLAM",
                    EMail = "zenaul@lee.com",
                    Star = 4.3,
                    Comment = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia res eos qui ratione voluptatem sequi Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci veli"
                }
                    };


            aspnetrunContext.Reviews.AddRange(reviews);
            await aspnetrunContext.SaveChangesAsync();

        }




        private static async Task SeedProductsAsync(DotNetAppContext aspnetrunContext)
        {
            if (aspnetrunContext.Reviews.Any())
                return;
            var products = new List<Product>
            {
                // Phone
                new Product()
                {
                    Name = "uPhone X",
                    Slug = "uphone-x",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                      Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolorsit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                     UnitPrice = 295,
                    UnitsInStock = 10,
                    Star = 4.3,
                    Category = aspnetrunContext.Categories.FirstOrDefault(c => c.Name == "Phone & Tablet"),

                    //Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                   // Tags = aspnetrunContext.Tags.ToList()
                      },
                new Product()
                {
                      Name = "Ornet Note 9",
                    Slug = "ornet-note",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo  dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-17.png",
                    UnitPrice = 285,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 4,
                   // Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews =
                    aspnetrunContext.Reviews.ToList(),
                    //Tags = aspnetrunContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Sany Experia Z5",
                    Slug = "sany-experia",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo  dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.Temporibus, voluptatibus.",
                    ImageFile = "product-24.png",
                    UnitPrice = 360,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 4,
                     //Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                   // Tags = aspnetrunContext.Tags.ToList()
                     },
                new Product()
                {
                    Name = "Flex P 3310",
                    Slug = "flex-p",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor  sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-19.png",
                    UnitPrice = 220,
                    UnitsInStock = 10,

                    Star = 4.3,
                    CategoryId = 4,
                    //Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                  //Tags = aspnetrunContext.Tags.ToList()
                    },
                // Camera                
                new Product()
                {
                    Name = "Mony Handycam Z 105",
                      Slug = "mony-handycam-z",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.,Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-5.png",
                     UnitPrice = 145,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 5,
                    //Specifications = aspnetrunContext.Specifications.ToList(),
                       Reviews = aspnetrunContext.Reviews.ToList(),
                   // Tags = aspnetrunContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Axor Digital Camera",

                    Slug = "axor-digital",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",

                     ImageFile = "product-6.png",
                    UnitPrice = 199,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 5,
                   // Specifications =aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                   // Tags = aspnetrunContext.Tags.ToList()
                }

            };
            aspnetrunContext.Products.AddRange(products);
            await aspnetrunContext.SaveChangesAsync();

        }
    }
}
