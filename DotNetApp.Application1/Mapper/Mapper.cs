using AutoMapper;
using DotNetApp.Application1.Models;
using DotNetApp.Application1.Models.Product;
using DotNetApp.Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetApp.Application1.Mapper
{
	public class AspnetRunProfileApplication : Profile
	{
		public AspnetRunProfileApplication()
		{
			CreateMap< Product, ProductModel>().ReverseMap();
			CreateMap< Category, CategoryModel>().ReverseMap();
		}
	}
}
