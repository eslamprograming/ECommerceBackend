using DAL.Data;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.SheardVM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext db;

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
                var category = await db.categories.
                    Where(n => n.CategoryID == CategoryID && n.IsDeleted == false).SingleOrDefaultAsync();
                if(category==null)
                {
                    return new Response<Category>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this category can not found"
                    };
                }
                else
                {
                    category.IsDeleted = true;
                    await db.SaveChangesAsync();
                }
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
                var CategoryCount = await db.categories.Where(n=>n.IsDeleted==false).CountAsync();
                int pagging;
                
                if (CategoryCount % 10 == 0)
                {
                    pagging=CategoryCount/ 10;
                }
                else
                {
                    pagging =(CategoryCount / 10) +1;
                }
                var category = await db.categories.Where(n => n.IsDeleted == false).Skip((group-1)*10).Take(10).ToListAsync();

                return new Response<Category>
                {
                    success = true,
                    statuscode = "200",
                    values=category,
                    groups=pagging

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
                var category = await db.categories.Where(n => n.IsDeleted == false).ToListAsync();
                return new Response<Category>
                {
                    success = true,
                    statuscode = "200",
                    values=category
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
                var category = await db.categories.
                    Where(n => n.CategoryID == CategoryID && n.IsDeleted == false).SingleOrDefaultAsync();
                if (category == null)
                {
                    return new Response<Category>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this category can not found"
                    };
                }

                return new Response<Category>
                {
                    success = true,
                    statuscode = "200",
                    Value = category
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
                var category1 = await db.categories.
                    Where(n => n.CategoryID == CategoryID && n.IsDeleted == false).SingleOrDefaultAsync();
                if (category1 == null)
                {
                    return new Response<Category>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this category can not found"
                    };
                }
                category1.CategoryName = category.CategoryName;
                await db.SaveChangesAsync();
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
