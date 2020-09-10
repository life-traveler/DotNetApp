using DotNetApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetApp.Core.Entities
{
   public  class Review : Entity
    {
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Comment { get; set; }
        public double Star { get; set; }
    }
}
