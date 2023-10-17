using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.CategoryVM;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<Response<Category>> CreateCategoryAsync(CategoryVM category)
        {
            try
            {
                Category category1 = new Category();
                category1.CategoryName = category.CategoryName;
                category1.IsDeleted = false;
                var result= await _categoryRepo.CreateCategoryRepo(category1);
                return result;

            }
            catch (Exception ex)
            {
                return new Response<Category>
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Category>> DeleteCategoryAsync(int CategoryID)
        {
            try
            {
                var result = await _categoryRepo.DeleteCategoryRepo(CategoryID); return result; 
            }
            catch (Exception ex)
            {
                return new Response<Category>
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Category>> GetAllCategoriesAsync(int group)
        {
            try
            {
                var result = await _categoryRepo.GetAllCategoriesRepo(group); return result;


            }
            catch (Exception ex)
            {
                return new Response<Category>
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Category>> GetAllCategoriesAsync()
        {
            try
            {
                var result = await _categoryRepo.GetAllCategoriesRepo(); return result;


            }
            catch (Exception ex)
            {
                return new Response<Category>
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Category>> GetCategoryAsync(int CategoryID)
        {
            try
            {

                var result = await _categoryRepo.GetCategoryRepo(CategoryID); return result;

            }
            catch (Exception ex)
            {
                return new Response<Category>
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }

        public async Task<Response<Category>> UpdateCategoryAsync(int CategoryID, CategoryVM category)
        {
            try
            {

                Category category1 = new Category();
                category1.CategoryName = category.CategoryName;
                var result=await _categoryRepo.UpdateCategoryRepo(CategoryID, category1);
                return result;

            }
            catch (Exception ex)
            {
                return new Response<Category>
                {
                    success = false,
                    statuscode = "500",
                    message = ex.Message
                };
            }
        }
    }
}
