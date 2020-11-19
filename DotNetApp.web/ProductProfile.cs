using AutoMapper;
using DotNetApp.Application1.Models;
using DotNetApp.Application1.Models.Product;
using DotNetApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetApp.Web
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductViewModel, ProductModel>().ReverseMap();
            CreateMap<CategoryViewModel, CategoryModel>().ReverseMap();
        }
    }
}
