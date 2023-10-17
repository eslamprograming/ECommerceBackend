using DAL.Entities;
using DAL.Models.OrderVM;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IOrderService
    {
        Task<Response<Order>> CreateOrderAsync(OrderVM Order);
        Task<Response<Order>> DeleteOrderAsync(int OrderID);
        Task<Response<Order>> GetAllOrdersAsync(int group);
        Task<Response<Order>> GetAllOrdersAsync();
        Task<Response<Order>> GetOrderAsync(int OrderID);
        Task<Response<Order>> UpdateOrderAsync(int OrderID, OrderVM Order);
    }
}
