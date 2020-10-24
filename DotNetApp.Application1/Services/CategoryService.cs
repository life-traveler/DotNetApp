using AutoMapper;
using DotNetApp.Application1.Interfaces;
using DotNetApp.Application1.Mapper;
using DotNetApp.Application1.Models;
using DotNetApp.Core.Interface;
using DotNetApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetApp.Application1.Services
{
 
        public class CategoryService : ICategoryService
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IAppLogger<CategoryService> _logger;

            public CategoryService(ICategoryRepository categoryRepository, IAppLogger<CategoryService> logger)
            {
                _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }




        public async Task<IEnumerable<CategoryModel>> GetCategoryList()
            {
                var category = await _categoryRepository.GetAllAsync();
                var mapped = ObjectMapperClass.Mapper.Map<IEnumerable<CategoryModel>>(category);
                return mapped;
            }

      
    }


    
}
