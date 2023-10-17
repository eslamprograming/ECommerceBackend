using DAL.Entities;
using DAL.Models.CategoryVM;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface ICategoryService
    {
        Task<Response<Category>> CreateCategoryAsync(CategoryVM category);
        Task<Response<Category>> DeleteCategoryAsync(int CategoryID);
        Task<Response<Category>> GetAllCategoriesAsync(int group);
        Task<Response<Category>> GetAllCategoriesAsync();
        Task<Response<Category>> GetCategoryAsync(int CategoryID);
        Task<Response<Category>> UpdateCategoryAsync(int CategoryID, CategoryVM category);
    }
}
