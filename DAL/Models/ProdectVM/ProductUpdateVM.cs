using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.ProdectVM
{
    public class ProductUpdateVM
    {
        [Required(ErrorMessage = "Enter ProductName")]
        public string ProductName { get; set; }
        
        [Required(ErrorMessage = "Enter Price")]

        public decimal Price { get; set; }
        [Required(ErrorMessage = "Enter Description")]

        public string Description { get; set; }
        [Required(ErrorMessage = "Enter StockQuantity")]

        public int StockQuantity { get; set; }
        [Required(ErrorMessage = "Enter Category")]

        public int CategoryID { get; set; }
    }
}
