using BLL.IService;
using DAL.Models.ProdectVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromForm]ProductVM productVM)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _productService.CreateProductAsync(productVM);
            return Ok(result);
        }
        [HttpDelete("DeleteProduct")]
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
        public async Task<IActionResult> UpdateProduct(int ProductID, [FromForm] ProductUpdateVM product) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _productService.UpdateProductAsync(ProductID, product);
            return Ok(result);
        }
    }
}
