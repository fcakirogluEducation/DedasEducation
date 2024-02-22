﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Products;

namespace Repositories.ProductFeatures
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Color { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;
    }
}