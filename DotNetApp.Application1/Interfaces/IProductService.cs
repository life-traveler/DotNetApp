using DotNetApp.Application1.Models.Product;
using DotNetApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetApp.Application1.Interfaces
{
   public  interface IProductService
    {
        //methods for products

        //we are returning productModel not product
        //add another method : editable 
        //separeate layer 
        Task<IEnumerable<ProductModel>> GetProductList();
        Task<ProductModel> GetProductById(int productId);
        Task<ProductModel> GetProductBySlug(string slug);
        Task<IEnumerable<ProductModel>> GetProductByName(string productName);
        Task<IEnumerable<ProductModel>> GetProductByCategory(int categoryId);
        Task<ProductModel> Create(ProductModel productModel);
        Task Update(ProductModel productModel);
        Task Delete(ProductModel productModel);
        Task<IQueryable<Product>> GetAllProducts();




    }
}
