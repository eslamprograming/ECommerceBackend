using BLL.IService;
using DAL.Models.CategoryVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromForm]CategoryVM categoryVM)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var result = await _categoryService.CreateCategoryAsync(categoryVM);
            return Ok(result);
        }
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int CategoryID)
        {
            if (CategoryID > 0)
            {
                var result = await _categoryService.DeleteCategoryAsync(CategoryID);
                return Ok(result);
            }
            return BadRequest("This Category not valid");
        }
        [HttpGet("GetAllCategoryGroup")]
        public async Task<IActionResult> GetAllCategoryGroup(int Group)
        {
            if(Group> 0)
            {
                var result=await _categoryService.GetAllCategoriesAsync(Group); return Ok(result);
            }
            return BadRequest("Error from front end");
        }
        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategroy()
        {
            var result = await _categoryService.GetAllCategoriesAsync(); return Ok(result);
        }
        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategroy(int CategoryID)
        {
            var result = await _categoryService.GetCategoryAsync(CategoryID); return Ok(result);
        }
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(int CategoryID,[FromForm]CategoryVM Category)
        {
            if (CategoryID > 0)
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var result = await _categoryService.UpdateCategoryAsync(CategoryID, Category);
                return Ok(result);
            }
            return BadRequest("Incorrect Category")
;        }

    }
}
