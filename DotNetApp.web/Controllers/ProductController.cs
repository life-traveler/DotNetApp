using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotNetApp.Web.Interface;
using DotNetApp.Web.Services;
using DotNetApp.Web.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DotNetApp.Web.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductPageService _productPageService;
        private readonly IIndexPageService _indexPageService;
        
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ICategoryPageService _categoryPageService;

        public ProductController(IProductPageService productPageService, IIndexPageService indexPageService, IWebHostEnvironment hostingEnvironment ,ICategoryPageService categoryPageService)
        {
           _productPageService =  productPageService;
            _indexPageService = indexPageService;
            _hostingEnvironment = hostingEnvironment;
            _categoryPageService = categoryPageService;
        }


        public async Task<IActionResult> Index(string sorting_order, int? pageNumber)
        {

            ViewData["CurrentSort"] = sorting_order;
            //if the sort parameter is null or empty then we are initializing the value as descending name
            ViewBag.SortByName = string.IsNullOrEmpty(sorting_order) ? "descending Name" : "";
            //if the sort value is gender then we are initializing the value as descending gender
            ViewBag.SortById = sorting_order == "Id" ? "descending Id" : "Id";


            IQueryable<ProductViewModel> ProductList = await _productPageService.GetAllProducts();

            switch (sorting_order)
            {

                case "descending Name":
                    ProductList = ProductList.OrderByDescending(x => x.Name);
                    break;

                case "descending Id":
                    ProductList = ProductList.OrderByDescending(x => x.Id);
                    break;

                case "Id":
                    ProductList = ProductList.OrderBy(x => x.Id);
                    break;

                default:
                    ProductList = ProductList.OrderBy(x => x.Name);
                    break;

            }
          

            int pageSize = 3;



            return View(await PaginatedList<ProductViewModel>.CreateAsync(ProductList.AsNoTracking(), pageNumber ?? 1, pageSize));

       

        }

        [HttpGet]
        public async Task<IActionResult> AddNewProduct()
        {
            ViewBag.Categories = new SelectList(await _categoryPageService.GetCategoryList1(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {

                if (productViewModel.ImageName != null)
                {
                    var filePath = _hostingEnvironment.WebRootPath + "Images/";
                    var fileName = productViewModel.ImageName.FileName;
                    string path = Path.Combine(filePath, fileName);

                    productViewModel.ImageName.CopyTo(new FileStream(path, FileMode.Create));
                    productViewModel.ImageFile = productViewModel.ImageName.FileName;
                }

               await _productPageService.AddNewProduct(productViewModel);
            }
            else
            {

            }
            return View();
        }



    }
}
