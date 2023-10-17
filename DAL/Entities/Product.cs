﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public int? StockQuantity { get; set; }
        public Category? Category { get; set; }
    }
}