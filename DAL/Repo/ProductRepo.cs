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
    public class ProductRepo : IProductRepo
    {
        private ApplicationDbContext db;

        public ProductRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<Product>> CreateProductRepo(Product Product)
        {
            try
            {
                return new Response<Product>
                {
                    success = true,
                    statuscode = "200",

                };
            }
            catch (Exception ex)
            {
                return new Response<Product>
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Product>> DeleteProductRepo(int ProductID)
        {
            try
            {
                return new Response<Product>
                {
                    success = true,
                    statuscode = "200",

                };
            }
            catch (Exception ex)
            {
                return new Response<Product>
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Product>> GetAllProductsRepo(int group)
        {
            try
            {
                return new Response<Product>
                {
                    success = true,
                    statuscode = "200",

                };
            }
            catch (Exception ex)
            {
                return new Response<Product>
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Product>> GetAllProductsRepo()
        {
            try
            {
                return new Response<Product>
                {
                    success = true,
                    statuscode = "200",

                };
            }
            catch (Exception ex)
            {
                return new Response<Product>
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Product>> GetProductRepo(int ProductID)
        {
            try
            {
                return new Response<Product>
                {
                    success = true,
                    statuscode = "200",

                };
            }
            catch (Exception ex)
            {
                return new Response<Product>
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Product>> UpdateProductRepo(int ProductID, Product Product)
        {
            try
            {
                return new Response<Product>
                {
                    success = true,
                    statuscode = "200",

                };
            }
            catch (Exception ex)
            {
                return new Response<Product>
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }
    }
}
