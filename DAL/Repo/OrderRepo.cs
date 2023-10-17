using DAL.Data;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.SheardVM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ApplicationDbContext db;

        public OrderRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<Order>> CreateOrderRepo(Order Order)
        {
            try
            {
                await db.orders.AddAsync(Order);
                await db.SaveChangesAsync();
                return new Response<Order>
                {
                    success = true,
                    statuscode = "200",
                    Value=Order
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
                var Order = await db.orders.Where(n => n.IsDeleted == false && n.OrderID == OrderID)
                    .SingleOrDefaultAsync();
                if(Order == null)
                {
                    return new Response<Order>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this order deleted"
                    };
                }
                Order.IsDeleted = true;
                await db.SaveChangesAsync();
                return new Response<Order>
                {
                    success = true,
                    statuscode = "200"

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
                var OrderCount = await db.orders.CountAsync();
                int pagging;

                if (OrderCount % 10 == 0)
                {
                    pagging = OrderCount / 10;
                }
                else
                {
                    pagging = (OrderCount / 10) + 1;
                }
                var Order = await db.orders.Skip((group - 1) * 10).Take(10).Include(n=>n.Products).ToListAsync();
                return new Response<Order>
                {
                    success = true,
                    statuscode = "200",
                    values=Order,
                    groups=pagging
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
                var Order = await db.orders.Where(n => n.IsDeleted == false).Include(n => n.Products).ToListAsync();
                return new Response<Order>
                {
                    success = true,
                    statuscode = "200",
                    values=Order
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
                var Order = await db.orders.Where(n => n.IsDeleted == false && n.OrderID==OrderID)
                    .Include(n => n.Products).SingleOrDefaultAsync();
                return new Response<Order>
                {
                    success = true,
                    statuscode = "200",
                    Value=Order
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
                var Order1 = await db.orders.Where(n => n.IsDeleted == false && n.OrderID == OrderID).SingleOrDefaultAsync();
                Order1.OrderDate=Order.OrderDate;
                Order1.Status = Order.Status;
                Order.Products = Order.Products;
                await db.SaveChangesAsync();
                return new Response<Order>
                {
                    success = true,
                    statuscode = "200"

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
