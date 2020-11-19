using DotNetApp.Web.ViewModels.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetApp.Web.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile ImageName { get; set; }
      
        public string PhotoPath { get; set; }

    }
}
