﻿using System;
using System.Collections.Generic;

namespace GenschiStockHandler.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal Price { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public Dictionary<string, object> Attributes { get; set; }

    }
}
