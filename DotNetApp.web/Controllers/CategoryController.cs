using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetApp.Web.Interface;
using DotNetApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApp.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryPageService _categoryPageService;


        public CategoryController( ICategoryPageService categoryPageService)
        {
            _categoryPageService = categoryPageService;
        }



        public async Task<IActionResult> Index()
        {


            IEnumerable<CategoryViewModel> CategoryList = await _categoryPageService.GetCategoryList();
             return  View(CategoryList);
        }


        
    }
}
