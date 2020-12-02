using DotNetApp.Core.Entities;
using DotNetApp.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DotNetApp.Core.Repositories
{

    public interface ICategoryRepository : IRepository<Category>
    {
        //Task<Category> GetCategoryWithProductsAsync(int categoryId);
        Task<Category> AddNewCategory(Category category);
        Task DeleteCategory(Category category);
        Task<Category> GetCategoryById(int id);


    }
}
