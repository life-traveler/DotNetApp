using AutoMapper;
using AutoMapper.QueryableExtensions;
using DotNetApp.Application1.Interfaces;
using DotNetApp.Application1.Models;
using DotNetApp.Core.Entities;
using DotNetApp.Core.Repositories;
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
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryAppService;
        private readonly IMapper _mapper;

        public CategoryPageService(ICategoryService categoryAppService, IMapper mapper, ICategoryRepository categoryRepository )
        {
            _categoryAppService = categoryAppService ?? throw new ArgumentNullException(nameof(categoryAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
             _categoryRepository = categoryRepository;
        }

        //public async Task<IEnumerable<CategoryViewModel>> GetCategories()
        //{
        //    var list = await _categoryAppService.GetCategoryList();
        //    var mapped = _mapper.Map<IEnumerable<CategoryViewModel>>(list);
        //    return mapped;
        //}

        public async Task<IEnumerable<CategoryViewModel>> GetCategoryList1()
        {
            var list = await _categoryAppService.GetCategoryList();
            var mapped = _mapper.Map<IEnumerable<CategoryViewModel>>(list);
            return mapped;

        }

        public async Task<IQueryable<CategoryViewModel>> GetAllCategories()
        {
            var list = await _categoryAppService.GetAllCategory();
            var mapped = _mapper.Map<IQueryable<CategoryViewModel>>(list);
            return mapped;
        }


        public async Task<IQueryable<CategoryViewModel>> GetAllCategory()
        {
            IQueryable<CategoryViewModel> query1;
            var category = await _categoryAppService.GetAllCategory();
            query1 = category.ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider);
            return query1;

        }

        public async Task<CategoryViewModel> AddNewCategory(CategoryViewModel categoryViewModel)
        {
            var mapped = _mapper.Map<Category>(categoryViewModel);
             await  _categoryRepository.AddNewCategory(mapped);
            return categoryViewModel;
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
          await  _categoryRepository.DeleteAsync(category);
        
        }
    }
}
