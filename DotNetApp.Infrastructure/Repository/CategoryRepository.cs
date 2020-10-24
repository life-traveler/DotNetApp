using DotNetApp.Core.Entities;
using DotNetApp.Core.Repositories;
using DotNetApp.Infrastructure.Data;
using DotNetApp.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetApp.Infrastructure.Repository
{
 
        public class CategoryRepository : Repository<Category>, ICategoryRepository
        {
            public CategoryRepository(DotNetAppContext dbContext) : base(dbContext)
            {
            }
        }

 
}
