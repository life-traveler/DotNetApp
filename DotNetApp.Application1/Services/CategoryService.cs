using AutoMapper;
using AutoMapper.QueryableExtensions;
using DotNetApp.Application1.Interfaces;
using DotNetApp.Application1.Mapper;
using DotNetApp.Application1.Models;
using DotNetApp.Core.Entities;
using DotNetApp.Core.Interface;
using DotNetApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetApp.Application1.Services
{
 
        public class CategoryService : ICategoryService
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IAppLogger<CategoryService> _logger;
            private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IAppLogger<CategoryService> logger , IMapper mapper)
            {
                _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
                 _mapper = mapper;
            }




        public async Task<IEnumerable<CategoryModel>> GetCategoryList()
            {
                var category = await _categoryRepository.GetAllAsync();
                var mapped = _mapper.Map<IEnumerable<CategoryModel>>(category.AsEnumerable());
                return mapped;
            }


        //public async Task<IQueryable<CategoryModel>> GetAllCategory()
        //{
        //    var category = await _categoryRepository.GetAll();
        //    var mapped = _mapper.Map<IQueryable<CategoryModel>>(category.AsEnumerable());
        //    return mapped;
        //}

        public async Task<IQueryable<Category>> GetAllCategory()
        {

            //IQueryable<CategoryModel> query1;
            //var category = await _categoryRepository.GetAll();

            //query1 = category.ProjectTo<CategoryModel>(_mapper);
            //return query1;


            IQueryable<CategoryModel> query1;
            var category = await _categoryRepository.GetAll();
            //query1 = category.ProjectTo<CategoryModel>(_mapper);
            return category;
        }

    }


    
}
