using DotNetApp.Core.Entities;
using DotNetApp.Core.Specification.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetApp.Core.Specification
{
    public class ProductWithCategorySpecification : BaseSpecification<Product>
    {
        public ProductWithCategorySpecification(string productName)
            //product will be called from baseSpecification which is a superclass
            //calling superclass with parameter product name 
            // fisrt will call superClass(base) constructor where it set the predicate first

            : base(p => p.Name.ToLower().Contains(productName.ToLower()))
        {
            //then will execute here
            AddInclude(p => p.Category);
        }

        public ProductWithCategorySpecification(int productId)
            : base(p => p.ID == productId)
        {
            AddInclude(p => p.Category);
        }

        public ProductWithCategorySpecification()
            : base(null)
        {
            AddInclude(p => p.Category);
        }
    }
}
