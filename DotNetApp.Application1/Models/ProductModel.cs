using DotNetApp.Application1.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetApp.Application1.Models.Product
{
   public  class ProductModel :BaseModel
    {
        //add somethong to productModel : not related to databse it is an intermediate model : Editable
        //something like ViewModel
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public double Star { get; set; }

        public int CategoryId { get; set; }
        public CategoryModel categoryModel { get; set;}
    }
}
