using DotNetApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetApp.Core.Entities
{
    public class Category : Entity
    {
       
       public string Name { get; set;}
       public string Description { get; set; }

        //WHY DO HAVE A CREATE METHOD
        public static Category Create(int Id, string name, string description = null)
        {
            var category = new Category
            {
                ID = Id,
                Name = name,
                Description = description

            };
            return category;
        }

    }

    
}
