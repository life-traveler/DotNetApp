using DotNetApp.Core.Entities;
using DotNetApp.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetApp.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        //please explain IList vs IEnumerable
        Task<IEnumerable<Product>> GetProductListAsync();
        Task<Product> GetProductBySlug(string slug);
        Task<IEnumerable<Product>> GetProductByNameAsync(string productName);

        Task<Product> GetProductByIdWithCategoryAsync(int productId);
        Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId);

        Task<Product> AddNewProduct(Product product);

    }
}
