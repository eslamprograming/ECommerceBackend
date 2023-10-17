using BLL.IService;
using DAL.Data;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.OrderVM;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly ApplicationDbContext db;

        public OrderService(IOrderRepo orderRepo, ApplicationDbContext db)
        {
            _orderRepo = orderRepo;
            this.db = db;
        }

        public async Task<Response<Order>> CreateOrderAsync(OrderVM Order)
        {
            try
            {
                List<Product> products = new List<Product>();
                Order order1 = new Order();
                order1.OrderDate = Order.OrderDate;
                order1.Status="stall";
                order1.ID = Order.APPlicationUserId;
                foreach (var item in Order.Products)
                {
                    var product = await db.products.FindAsync(item);
                    products.Add(product);
                }
                order1.Products = products;
                order1.IsDeleted = false;
                var result = await _orderRepo.CreateOrderRepo(order1);
                return result;
            }
            catch (Exception ex)
            {
                return new Response<Order>
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Order>> DeleteOrderAsync(int OrderID)
        {
            try
            {
                var result=await _orderRepo.DeleteOrderRepo(OrderID);
                return result;
            }
            catch (Exception ex)
            {
                return new Response<Order>
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Order>> GetAllOrdersAsync(int group)
        {
            try
            {
                var result=await _orderRepo.GetAllOrdersRepo(group);
                return result;
            }
            catch (Exception ex)
            {
                return new Response<Order>
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Order>> GetAllOrdersAsync()
        {
            try
            {
                var result = await _orderRepo.GetAllOrdersRepo();
                return result;
            }
            catch (Exception ex)
            {
                return new Response<Order>
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Order>> GetOrderAsync(int OrderID)
        {
            try
            {
                var result=await _orderRepo.GetOrderRepo(OrderID);
                return result;
            }
            catch (Exception ex)
            {
                return new Response<Order>
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Order>> UpdateOrderAsync(int OrderID, OrderVM Order)
        {
            try
            {
                List<Product> products = new List<Product>();
                Order order1 = new Order();
                order1.OrderDate = Order.OrderDate;
                order1.Status = "stall";
                order1.ID = Order.APPlicationUserId;
                foreach (var item in Order.Products)
                {
                    var product = await db.products.FindAsync(item);
                    products.Add(product);
                }
                order1.Products = products;
                var result = await _orderRepo.UpdateOrderRepo(OrderID, order1);
                return result;
            }
            catch (Exception ex)
            {
                return new Response<Order>
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }
    }
}
