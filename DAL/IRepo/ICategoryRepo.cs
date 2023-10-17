using DAL.Entities;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface ICategoryRepo
    {
        Task<Response<Category>> CreateCategoryRepo(Category category);
        Task<Response<Category>> DeleteCategoryRepo(int CategoryID);
        Task<Response<Category>> GetAllCategoriesRepo(int group);
        Task<Response<Category>> GetAllCategoriesRepo();

        Task<Response<Category>> GetCategoryRepo(int CategoryID);
        Task<Response<Category>> UpdateCategoryRepo(int CategoryID,Category category);

    }
}
