using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetApp.Application1.Interfaces;
using DotNetApp.Application1.Models;
using DotNetApp.Application1.Services;
using DotNetApp.Core.Entities;
using DotNetApp.Web.Interface;
using DotNetApp.Web.Services;
using DotNetApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetApp.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryPageService _categoryPageService;
        private readonly IIndexPageService _indexPageService;
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryPageService categoryPageService, IIndexPageService indexPageService, ICategoryService categoryService )
        {
            _categoryPageService = categoryPageService;
            _indexPageService = indexPageService;
           _categoryService = categoryService;
        }


       

        //public async Task<IActionResult> Index(string sorting_order , int? pageIndex)
        //{
        //    //ViewBag.sortingCategoryName = String.IsNullOrEmpty(sorting_order) ? "Name" : "";
        //    ////ViewBag.sortingId = String.IsNullOrEmpty(sorting_order) ? "Id" : "";
        //    //ViewBag.sortingId = sorting_order == "Id" ? "Id" : "";

        //    //if the sort parameter is null or empty then we are initializing the value as descending name  
        //    ViewBag.SortByName = string.IsNullOrEmpty(sorting_order) ? "descending Name" : "";
        //    //if the sort value is gender then we are initializing the value as descending gender  
        //    ViewBag.SortById = sorting_order == "Id" ? "descending Id" : "Id";


        //    //IEnumerable<ProductViewModel> ProductList = await _indexPageService.GetProducts();
        //    IEnumerable<CategoryViewModel> CategoryList = await _categoryPageService.GetCategoryList1();

        //    //switch (sorting_order)
        //    //{
        //    //    case "Name":
        //    //        CategoryList = CategoryList.OrderByDescending(c => c.Name);
        //    //        break;
        //    //    case "Id":
        //    //        CategoryList = CategoryList.OrderBy(c =>c.Id);
        //    //        break;

        //    //    default:
        //    //        CategoryList = CategoryList.OrderBy(c => c.Name);
        //    //        break;
        //    //}

        //    switch (sorting_order)
        //    {

        //        case "descending Name":
        //            CategoryList = CategoryList.OrderByDescending(x =>  x.Name);
        //            break;

        //        case "descending Id":
        //            CategoryList = CategoryList.OrderByDescending(x => x.Id);
        //            break;

        //        case "Id":
        //            CategoryList = CategoryList.OrderBy(x => x.Id);
        //            break;

        //        default:
        //            CategoryList = CategoryList.OrderBy(x => x.Name);
        //            break;

        //    }
        //    var queryableX = CategoryList.AsQueryable();

        //    int pageSize = 3;
        //    var categoryList = await PaginatedList<CategoryViewModel>.CreateAsync(

        //        queryableX.AsNoTracking(), pageIndex ?? 1, pageSize);


        //    //var sortedCategory = CategoryList.OrderBy(c => c.Name);
        //    return  View(CategoryList);
        //}


        public async Task<IActionResult> Index(string sorting_order, int? pageIndex)
        {
            //ViewBag.sortingCategoryName = String.IsNullOrEmpty(sorting_order) ? "Name" : "";
            ////ViewBag.sortingId = String.IsNullOrEmpty(sorting_order) ? "Id" : "";
            //ViewBag.sortingId = sorting_order == "Id" ? "Id" : "";

            //if the sort parameter is null or empty then we are initializing the value as descending name
            ViewBag.SortByName = string.IsNullOrEmpty(sorting_order) ? "descending Name" : "";
            //if the sort value is gender then we are initializing the value as descending gender
            ViewBag.SortById = sorting_order == "Id" ? "descending Id" : "Id";



            IQueryable<CategoryViewModel> CategoryList = await _categoryPageService.GetAllCategory();
            //IEnumerable<ProductViewModel> ProductList = await _indexPageService.GetProducts();
           // IEnumerable<CategoryViewModel> CategoryList = await _categoryPageService.GetCategoryList1();

            //switch (sorting_order)
            //{
            // case "Name":
            // CategoryList = CategoryList.OrderByDescending(c => c.Name);
            // break;
            // case "Id":
            // CategoryList = CategoryList.OrderBy(c =>c.Id);
            // break;

            // default:
            // CategoryList = CategoryList.OrderBy(c => c.Name);
            // break;
            //}

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
            //CategoryList = await PaginatedList<CategoryViewModel>.CreateAsync(CategoryList.AsNoTracking(), pageIndex ?? 1, pageSize);

            return View(await PaginatedList<CategoryViewModel>.CreateAsync(CategoryList.AsNoTracking(), pageIndex ?? 1, pageSize));
            //var sortedCategory = CategoryList.OrderBy(c => c.Name);
            //return View(CategoryList);

        }

      
    }
}
