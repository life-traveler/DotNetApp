using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotNetApp.Application1.Interfaces;
using DotNetApp.Application1.Models;
using DotNetApp.Application1.Services;
using DotNetApp.Core.Entities;
using DotNetApp.Web.Interface;
using DotNetApp.Web.Services;
using DotNetApp.Web.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetApp.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryPageService _categoryPageService;
        private readonly IIndexPageService _indexPageService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CategoryController(ICategoryPageService categoryPageService, IIndexPageService indexPageService, ICategoryService categoryService, IWebHostEnvironment hostingEnvironment)
        {
            _categoryPageService = categoryPageService;
            _indexPageService = indexPageService;
           _categoryService = categoryService;
            _hostingEnvironment = hostingEnvironment;
    }



      

        public async Task<IActionResult> Index(string sorting_order, int? pageNumber)
        {
           
            ViewData["CurrentSort"] = sorting_order;
            //if the sort parameter is null or empty then we are initializing the value as descending name
            ViewBag.SortByName = string.IsNullOrEmpty(sorting_order) ? "descending Name" : "";
            //if the sort value is gender then we are initializing the value as descending gender
            ViewBag.SortById = sorting_order == "Id" ? "descending Id" : "Id";


            IQueryable<CategoryViewModel> CategoryList = await _categoryPageService.GetAllCategory();
           
            switch (sorting_order)
            {

                case "descending Name":
                    CategoryList = CategoryList.OrderByDescending(x => x.Name);
                    break;

                case "descending Id":
                    CategoryList = CategoryList.OrderByDescending(x => x.Id);
                    break;

                case "Id":
                    CategoryList = CategoryList.OrderBy(x => x.Id);
                    break;

                default:
                    CategoryList = CategoryList.OrderBy(x => x.Name);
                    break;

            }
            //var queryableX = CategoryList.AsQueryable();

            int pageSize = 3;
     

        
            return View(await PaginatedList<CategoryViewModel>.CreateAsync(CategoryList.AsNoTracking(), pageNumber ?? 1, pageSize));

            //var sortedCategory = CategoryList.OrderBy(c => c.Name);
            //return View(CategoryList);

        }

        [HttpGet]
        public async Task<IActionResult> AddNewCategory()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCategory(CategoryViewModel categoryViewModel)
        {
            if(ModelState.IsValid)
            {
                if(categoryViewModel.ImageName != null)
                {
                    var filePath = _hostingEnvironment.WebRootPath + "Images/";
                    var fileName = categoryViewModel.ImageName.FileName;
                    string path = Path.Combine(filePath, fileName);
                    
                    categoryViewModel.ImageName.CopyTo(new FileStream(path, FileMode.Create));
                    categoryViewModel.PhotoPath = categoryViewModel.ImageName.FileName; 
                }

                _categoryPageService.AddNewCategory(categoryViewModel);

            }
            else
            {
               
            }
            return View();
        }


        public async Task<IActionResult> Delete(int id)
        {
          await  _categoryPageService.DeleteCategory(id);

            return RedirectToAction("index" , new { sorting_order =""});
        }
    }

}
