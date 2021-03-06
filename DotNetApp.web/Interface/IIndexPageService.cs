﻿using DotNetApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetApp.Web.Interface
{
   public interface IIndexPageService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();

    }
}
