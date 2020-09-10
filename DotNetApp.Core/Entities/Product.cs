using DotNetApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNetApp.Core.Entities
{
   public  class Product : Entity 
    {
        [Required, StringLength(80)]
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public double Star { get; set; }



        // n-1 relationships
        //
        public int CategoryId { get; set; }

      //collect 
        public Category Category { get; set; }

        // 1-n relationships
        public List<Review> Reviews { get; set; } = new List<Review>();
        
    }
}
