using DAL.Entities;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IProductRepo
    {
        Task<Response<Product>> CreateProductRepo(Product Product);
        Task<Response<Product>> DeleteProductRepo(int ProductID);
        Task<Response<Product>> GetAllProductsRepo(int group);
        Task<Response<Product>> GetAllProductsInCategoryRepo(int CategoryID);
        Task<Response<Product>> GetAllProductsRepo();
        Task<Response<Product>> GetProductRepo(int ProductID);
        Task<Response<Product>> UpdateProductRepo(int ProductID, Product Product);
    }
}
