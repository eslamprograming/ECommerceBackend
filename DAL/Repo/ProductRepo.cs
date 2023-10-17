using DAL.Data;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.SheardVM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext db;

        public ProductRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<Product>> CreateProductRepo(Product Product)
        {
            try
            {
                await db.products.AddAsync(Product);
                await db.SaveChangesAsync();
                return new Response<Product>
                {
                    success = true,
                    statuscode = "200",
                    Value=Product
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
                var product = await db.products.FindAsync(ProductID);
                db.products.Remove(product);
                await db.SaveChangesAsync();
                return new Response<Product>
                {
                    success = true,
                    statuscode = "200",
                    Value=product
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

        public async Task<Response<Product>> GetAllProductsInCategoryRepo(int CategoryID)
        {
            try
            {
                var product = await db.products.Where(n=>n.CategoryID==CategoryID).ToListAsync();

                return new Response<Product>
                {
                    success = true,
                    statuscode = "200",
                    values = product
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
                var productCount = await db.products.CountAsync();
                int pagging;

                if (productCount % 10 == 0)
                {
                    pagging = productCount / 10;
                }
                else
                {
                    pagging = (productCount / 10) + 1;
                }
                var product = await db.products.Skip((group - 1) * 10).Take(10).ToListAsync();

                return new Response<Product>
                {
                    success = true,
                    statuscode = "200",
                    values = product,
                    groups = pagging
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
                var product = await db.products.ToListAsync();

                return new Response<Product>
                {
                    success = true,
                    statuscode = "200",
                    values = product
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
                var product = await db.products.FindAsync(ProductID);
                return new Response<Product>
                {
                    success = true,
                    statuscode = "200",
                    Value=product
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
                var product1 = await db.products.FindAsync(ProductID);
                product1.Description=Product.Description;
                product1.CategoryID=Product.CategoryID;
                product1.Price = Product.Price;
                product1.ProductName = Product.ProductName;
                product1.StockQuantity = Product.StockQuantity;
                await db.SaveChangesAsync();
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
