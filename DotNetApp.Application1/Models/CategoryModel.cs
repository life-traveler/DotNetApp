using DotNetApp.Application1.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetApp.Application1.Models
{
   public  class CategoryModel : BaseModel 
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string PhotoPath { get; set; }

    }
}
