using DotNetApp.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetApp.Application.Models
{
   public  class CategoryModel : BaseModel 
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
