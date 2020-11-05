﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public class BrandModel
    {
        public string parent_brand_id { get; set; }
        public string brand_id { get; set; }
        public string brand_name { get; set; }
        public string desc { get; set; }
        public string url { get; set; }
        public List<BrandModel> children { get; set; }
        public string type { get; set; }
    }
}
