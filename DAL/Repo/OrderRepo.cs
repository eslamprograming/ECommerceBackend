using DAL.Data;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class OrderRepo : IOrderRepo
    {
        private ApplicationDbContext db;

        public OrderRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<Order>> CreateOrderRepo(Order Order)
        {
            try
            {
                return new Response<Order>
                {
                    success = true,
                    statuscode = "200",

                };
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

        public async Task<Response<Order>> DeleteOrderRepo(int OrderID)
        {
            try
            {
                return new Response<Order>
                {
                    success = true,
                    statuscode = "200",

                };
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

        public async Task<Response<Order>> GetAllOrdersRepo(int group)
        {
            try
            {

                return new Response<Order>
                {
                    success = true,
                    statuscode = "200",

                };
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

        public async Task<Response<Order>> GetAllOrdersRepo()
        {
            try
            {
                return new Response<Order>
                {
                    success = true,
                    statuscode = "200",

                };
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

        public async Task<Response<Order>> GetOrderRepo(int OrderID)
        {
            try
            {
                return new Response<Order>
                {
                    success = true,
                    statuscode = "200",

                };
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

        public async Task<Response<Order>> UpdateOrderRepo(int OrderID, Order Order)
        {
            try
            {
                return new Response<Order>
                {
                    success = true,
                    statuscode = "200",

                };
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
