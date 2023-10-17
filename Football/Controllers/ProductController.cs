using BLL.IService;
using DAL.Entities;
using DAL.Models.ProdectVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductController(IProductService productService, UserManager<ApplicationUser> userManager)
        {
            _productService = productService;
            _userManager = userManager;
        }
        [HttpPost("AddProduct")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddProduct([FromForm]ProductVM productVM)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _productService.CreateProductAsync(productVM);
            return Ok(result);
        }
        [HttpDelete("DeleteProduct")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteProduct(int ProductID)
        {
            if (ProductID > 0)
            {
                var result = await _productService.DeleteProductAsync(ProductID);
                return Ok(result);
            }
            return BadRequest("invalid Product");
        }
        [HttpGet("GetAllProductGroup")]
        public async Task<IActionResult> GetAllProductGroup(int Group)
        {
            if (Group > 0)
            {
                var result = await _productService.GetAllCategoriesAsync(Group);
                return Ok(result);
            }
            return BadRequest("Invalid");
        }
        [HttpGet("GetAllProductCategory")]
        public async Task<IActionResult> GetAllProductCategory(int CategoryID)
        {
            if (CategoryID > 0)
            {
                var result = await _productService.GetAllproductCategoryAsync(CategoryID);
                return Ok(result);
            }
            return BadRequest("Invalid");
        }

        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _productService.GetAllCategoriesAsync();
            return Ok(result);
        }
        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(int ProductID)
        {
            if (ProductID > 0)
            {
                var result = await _productService.GetProductAsync(ProductID);
                return Ok(result);
            }
            return BadRequest("Invalid");
        }
        [HttpPut("UpdateProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct(int ProductID, [FromForm] ProductUpdateVM product) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _productService.UpdateProductAsync(ProductID, product);
            return Ok(result);
        }
    }
}
