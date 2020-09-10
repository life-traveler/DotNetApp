using DotNetApp.Core.Entities;
using DotNetApp.Core.Specification.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetApp.Core.Specification
{
    public class ProductSlugSpecification : BaseSpecification<Product>
    {
        public ProductSlugSpecification(string slug) :base ( p => p.Slug.ToLower().Contains(slug.ToLower()))
        {
            AddInclude(p => p.Category);
            AddInclude(p =>p.Reviews);
        }
    }
}
