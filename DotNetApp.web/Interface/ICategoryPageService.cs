using DotNetApp.Application1.Models;
using DotNetApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetApp.Web.Interface
{
    public interface ICategoryPageService
    {

        Task<IEnumerable<CategoryViewModel>> GetCategoryList1();
        Task<IQueryable<CategoryViewModel>> GetAllCategory();
        Task<CategoryViewModel> AddNewCategory(CategoryViewModel categoryViewModel);

        Task DeleteCategory( int id);



    }
}
