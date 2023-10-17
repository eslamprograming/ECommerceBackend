using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.ProdectVM;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<Response<Product>> CreateProductAsync(ProductVM Product)
        {
            try
            {
                Product product1 = new Product();
                product1.ProductName = Product.ProductName;
                product1.Price = Product.Price;
                product1.Description = Product.Description;
                product1.StockQuantity = Product.StockQuantity;
                product1.CategoryID = Product.CategoryID;

                var URL =  Helper.File.Save(Product.ProductImageURL);
                product1.ProductImageURL = URL;
                var result = await _productRepo.CreateProductRepo(product1);
                return result;

            }
            catch (Exception ex)
            {
                return new Response<Product>
                {
                    success = false,
                    statuscode="500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Product>> DeleteProductAsync(int ProductID)
        {
            try
            {
                var result = await _productRepo.DeleteProductRepo(ProductID);
                if (result.success == true)
                {
                    Helper.File.DeleteFileByLink(result.Value.ProductImageURL);
                }
                return result;
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

        public async Task<Response<Product>> GetAllCategoriesAsync(int group)
        {
            try
            {
                var result = await _productRepo.GetAllProductsRepo(group);
                return result;
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

        public async Task<Response<Product>> GetAllCategoriesAsync()
        {
            try
            {
                var result = await _productRepo.GetAllProductsRepo();
                return result;
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

        public async Task<Response<Product>> GetAllproductCategoryAsync(int CategoryID)
        {
            try
            {
                var result = await _productRepo.GetAllProductsInCategoryRepo(CategoryID);
                return result;
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

        public async Task<Response<Product>> GetProductAsync(int ProductID)
        {
            try
            {
                var result = await _productRepo.GetProductRepo(ProductID);
                return result;
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

        public async Task<Response<Product>> UpdateProductAsync(int ProductID, ProductUpdateVM Product)
        {
            try
            {
                Product product1 = new Product();
                product1.ProductName = Product.ProductName;
                product1.Price = Product.Price;
                product1.Description = Product.Description;
                product1.StockQuantity = Product.StockQuantity;
                product1.CategoryID = Product.CategoryID;

                var result=await _productRepo.UpdateProductRepo(ProductID,product1);
                return result;
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
