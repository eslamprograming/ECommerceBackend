using DAL.Entities;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IOrderRepo
    {
        Task<Response<Order>> CreateOrderRepo(Order Order);
        Task<Response<Order>> DeleteOrderRepo(int OrderID);
        Task<Response<Order>> GetAllOrdersRepo(int group);
        Task<Response<Order>> GetAllOrdersRepo();
        Task<Response<Order>> GetOrderRepo(int OrderID);
        Task<Response<Order>> UpdateOrderRepo(int OrderID, Order Order);
    }
}
