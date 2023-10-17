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
    public class CategoryRepo : ICategoryRepo
    {
        private ApplicationDbContext db;

        public CategoryRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<Category>> CreateCategoryRepo(Category category)
        {
            try
            {
                await db.categories.AddAsync(category);
                await db.SaveChangesAsync();
                return new Response<Category>
                {
                    success = true,
                    statuscode="200",
                    Value=category
                };
            }
            catch (Exception ex)
            {
                return new Response<Category>
                {
                    success= false,
                    statuscode="500",
                    message=ex.Message
                };
            }
        }

        public async Task<Response<Category>> DeleteCategoryRepo(int CategoryID)
        {
            try
            {
                
                return new Response<Category>
                {
                    success = true,
                    statuscode = "200",

                };
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

        public async Task<Response<Category>> GetAllCategoriesRepo(int group)
        {
            try
            {
                return new Response<Category>
                {
                    success = true,
                    statuscode = "200",

                };
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

        public async Task<Response<Category>> GetAllCategoriesRepo()
        {
            try
            {
                return new Response<Category>
                {
                    success = true,
                    statuscode = "200",

                };
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

        public async Task<Response<Category>> GetCategoryRepo(int CategoryID)
        {
            try
            {
                return new Response<Category>
                {
                    success = true,
                    statuscode = "200",

                };
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

        public async Task<Response<Category>> UpdateCategoryRepo(int CategoryID, Category category)
        {
            try
            {
                return new Response<Category>
                {
                    success = true,
                    statuscode = "200",

                };
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
