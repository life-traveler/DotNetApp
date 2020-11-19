using AutoMapper;
using DotNetApp.Application1.Models;
using DotNetApp.Application1.Models.Product;
using DotNetApp.Core.Entities;
using DotNetApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetApp.Web.Mapper
{
	public class AspnetRunProfile : Profile
	{
		public AspnetRunProfile()
		{
			CreateMap<ProductModel, ProductViewModel>();
			CreateMap<CategoryModel, CategoryViewModel>();
			CreateMap<Category, CategoryViewModel>().ReverseMap();
		}
	}
}
