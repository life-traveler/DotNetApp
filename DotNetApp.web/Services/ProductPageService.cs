using AutoMapper;
using AutoMapper.QueryableExtensions;
using DotNetApp.Application1.Interfaces;
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
    public class ProductPageService : IProductPageService
    {



        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductPageService(IProductRepository productRepository , IMapper mapper, IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
             _productRepository = productRepository;
        }

        public async Task<ProductViewModel> AddNewProduct(ProductViewModel productViewModel)
        {

           var mapped = _mapper.Map<Product>(productViewModel);
           await  _productRepository.AddNewProduct(mapped);
      
            return productViewModel;
        }

        public Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<ProductViewModel>> GetAllProducts()
        {
            //var list = await _productService.GetAllProducts();
            //var mapped = _mapper.Map<IQueryable<ProductViewModel>>(list);
            //return mapped;



            IQueryable<ProductViewModel> query1;
            var category = await _productService.GetAllProducts();
            query1 = category.ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
            return query1;
        }

        public Task<ProductViewModel> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductViewModel>> GetProductList()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(ProductViewModel productViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
