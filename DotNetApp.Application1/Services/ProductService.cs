using AutoMapper;
using DotNetApp.Application1.Interfaces;
using DotNetApp.Application1.Mapper;
using DotNetApp.Application1.Models.Product;
using DotNetApp.Core.Entities;
using DotNetApp.Core.Interface;
using DotNetApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetApp.Application1.Services
{
   //we collect information from the database as in domain model format . We need to map to the (view model format from domain model format
   //so we use mapper(object mapper)

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IAppLogger<ProductService> _logger;
        private readonly IMapper _mapper;

        //initialization of service
        public ProductService(IProductRepository productRepository, IAppLogger<ProductService> logger ,IMapper mapper)
        {

            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductModel>> GetProductList()
        {
            var productList = await _productRepository.GetProductListAsync();
            //return type is product model type but we need product type so , we do mapping 
            //conevrt productList to productModel
            //source productList
            //destination IEn<ProdutModel>
            var mapped = _mapper.Map<IEnumerable<ProductModel>>(productList);
            return mapped;
        }

        public async Task<ProductModel> GetProductById(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            var mapped = _mapper.Map<ProductModel>(product);
            return mapped;
        }

        public async Task<ProductModel> GetProductBySlug(string slug)
        {
            var product = await _productRepository.GetProductBySlug(slug);
            var mapped = _mapper.Map<ProductModel>(product);
            return mapped;
        }

        public async Task<IEnumerable<ProductModel>> GetProductByName(string productName)
        {
            var productList = await _productRepository.GetProductByNameAsync(productName);
            var mapped = _mapper.Map<IEnumerable<ProductModel>>(productList);
            return mapped;
        }

        public async Task<IEnumerable<ProductModel>> GetProductByCategory(int categoryId)
        {
            var productList = await _productRepository.GetProductByCategoryAsync(categoryId);
            var mapped = _mapper.Map<IEnumerable<ProductModel>>(productList);
            return mapped;
        }


        //add new product by Admin
        public async Task<ProductModel> Create(ProductModel productModel)
        {
            await ValidateProductIfExist(productModel);

            var mappedEntity = _mapper.Map<Product>(productModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _productRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = _mapper.Map<ProductModel>(newEntity);
            return newMappedEntity;
        }

        public async Task Update(ProductModel productModel)
        {
            ValidateProductIfNotExist(productModel);

            var editProduct = await _productRepository.GetByIdAsync(productModel.Id);
            if (editProduct == null)
                throw new ApplicationException($"Entity could not be loaded.");

            _mapper.Map<ProductModel, Product>(productModel, editProduct);

            await _productRepository.UpdateAsync(editProduct);
            _logger.LogInformation($"Entity successfully updated - AspnetRunAppService");
        }

        public async Task Delete(ProductModel productModel)
        {
            ValidateProductIfNotExist(productModel);
            var deletedProduct = await _productRepository.GetByIdAsync(productModel.Id);
            if (deletedProduct == null)
                throw new ApplicationException($"Entity could not be loaded.");

            await _productRepository.DeleteAsync(deletedProduct);
            _logger.LogInformation($"Entity successfully deleted - AspnetRunAppService");
        }

        //custom validation 
        private async Task ValidateProductIfExist(ProductModel productModel)
        {
            var existingEntity = await _productRepository.GetByIdAsync(productModel.Id);
            if (existingEntity != null)
                throw new ApplicationException($"{productModel.ToString()} with this id already exists");
        }

        private void ValidateProductIfNotExist(ProductModel productModel)
        {
            var existingEntity = _productRepository.GetByIdAsync(productModel.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{productModel.ToString()} with this id is not exists");
        }
    }
}
