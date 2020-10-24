using AutoMapper;
using DotNetApp.Application1.Interfaces;
using DotNetApp.Application1.Models;
using DotNetApp.Web.Interface;
using DotNetApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetApp.Web.Services
{
 //productModel map to productViewModel
 //mapping done here instead of controller

    public class CategoryPageService : ICategoryPageService
    {
        private readonly ICategoryService _categoryAppService;
        private readonly IMapper _mapper;

        public CategoryPageService(ICategoryService categoryAppService, IMapper mapper)
        {
            _categoryAppService = categoryAppService ?? throw new ArgumentNullException(nameof(categoryAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //public async Task<IEnumerable<CategoryViewModel>> GetCategories()
        //{
        //    var list = await _categoryAppService.GetCategoryList();
        //    var mapped = _mapper.Map<IEnumerable<CategoryViewModel>>(list);
        //    return mapped;
        //}

        public async Task<IEnumerable<CategoryViewModel>> GetCategoryList()
        {
            var list = await _categoryAppService.GetCategoryList();
            var mapped = _mapper.Map<IEnumerable<CategoryViewModel>>(list);
            return mapped;

        }
    }
}
