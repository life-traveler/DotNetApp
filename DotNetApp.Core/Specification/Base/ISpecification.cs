using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DotNetApp.Core.Specification.Base
{
    //custom implementation for linq 
   public  interface ISpecification<T>
    {
        //properties
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }

       //general object
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        int Take { get; }
        int Skip { get; }
        bool isPagingEnabled { get; }

       // customer custoerObject = new customer();
       // object data = (casttype)customerObject
    }
}
