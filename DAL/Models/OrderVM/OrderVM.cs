using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.OrderVM
{
    public class OrderVM
    {
        public DateTime OrderDate { get; set; }
        public List<int> Products { get; set; }
        public string? APPlicationUserId { get; set; }
    }
}
