using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Status { get; set; }
        public virtual ICollection<Product>? Products { get; set; }  
        public ApplicationUser? User { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
