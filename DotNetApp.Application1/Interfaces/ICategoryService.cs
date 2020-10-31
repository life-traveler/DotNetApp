using DotNetApp.Application1.Models;
using DotNetApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetApp.Application1.Interfaces
{


        public interface ICategoryService
        {
            Task<IEnumerable<CategoryModel>> GetCategoryList();
            Task<IQueryable<Category>>GetAllCategory();
        }


   


}
