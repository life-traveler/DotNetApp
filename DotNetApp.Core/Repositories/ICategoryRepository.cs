using DotNetApp.Core.Entities;
using DotNetApp.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetApp.Core.Repositories
{

    public interface ICategoryRepository : IRepository<Category>
    {
        //Task<Category> GetCategoryWithProductsAsync(int categoryId);


    }
}
