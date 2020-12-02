using DotNetApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetApp.Web.Interface
{
   public  interface IProductPageService
    {

        Task<IEnumerable<ProductViewModel>> GetProductList();
        Task<IQueryable<ProductViewModel>> GetAllProducts();
        Task<ProductViewModel> AddNewProduct(ProductViewModel productViewModel);

        Task DeleteProduct(int id);
        Task<ProductViewModel> GetProductById(int id);
        Task UpdateProduct(ProductViewModel productViewModel);

       
    }
}
