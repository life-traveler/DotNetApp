using AutoMapper;
using DotNetApp.Application.Models;
using DotNetApp.Application.Models.Product;
using DotNetApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetApp.Application.Mapper
{
    public class ObjectMapperClass
    {
        public static IMapper Mapper
        {
            get
            {
                return AutoMapper.Mapper.Instance;
            }
        }
        static ObjectMapperClass()
        {
            CreateMap();
        }

     
        //}

        private static void CreateMap()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductModel>()
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ReverseMap();

                cfg.CreateMap<Category, CategoryModel>().ReverseMap();
                cfg.CreateMap<Review, ReviewModel>().ReverseMap();
                //cfg.CreateMap<Wishlist, WishlistModel>().ReverseMap();
                //cfg.CreateMap<Compare, CompareModel>().ReverseMap();
                //cfg.CreateMap<Order, OrderModel>().ReverseMap();
            });
        }
    }
}
       
  


