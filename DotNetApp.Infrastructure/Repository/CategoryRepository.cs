using DotNetApp.Core.Entities;
using DotNetApp.Core.Repositories;
using DotNetApp.Infrastructure.Data;
using DotNetApp.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetApp.Infrastructure.Repository
{
 
        public class CategoryRepository : Repository<Category>, ICategoryRepository
        {
            public CategoryRepository(DotNetAppContext dbContext) : base(dbContext)
            {
            }

        public async Task<Category> AddNewCategory(Category category)
        {
           return await AddAsync(category);
        }

        public async Task DeleteCategory(Category category)
        {
             await DeleteAsync(category);
        }


        public async Task<Category> GetCategoryById(int id)
        {
            return await GetByIdAsync(id);
        }
    }

 
}
