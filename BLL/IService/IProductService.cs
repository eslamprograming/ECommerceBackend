using DAL.Entities;
using DAL.Models.ProdectVM;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IProductService
    {
        Task<Response<Product>> CreateProductAsync(ProductVM Product);
        Task<Response<Product>> DeleteProductAsync(int ProductID);
        Task<Response<Product>> GetAllCategoriesAsync(int group);
        Task<Response<Product>> GetAllproductCategoryAsync(int CategoryID);
        Task<Response<Product>> GetAllCategoriesAsync();
        Task<Response<Product>> GetProductAsync(int ProductID);
        Task<Response<Product>> UpdateProductAsync(int ProductID, ProductUpdateVM Product);
    }
}
