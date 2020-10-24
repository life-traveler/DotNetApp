using DotNetApp.Application1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetApp.Application1.Interfaces
{


        public interface ICategoryService
        {
            Task<IEnumerable<CategoryModel>> GetCategoryList();
        }

    



    
}
