﻿using DotNetApp.Application1.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetApp.Application1.Models
{
  public   class ReviewModel : BaseModel
    {
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Comment { get; set; }
        public double Star { get; set; }
    }
}
