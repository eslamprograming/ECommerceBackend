using BLL.IService;
using BLL.Service;
using DAL.Models.OrderVM;
using DAL.Models.ProdectVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("AddOrder")]
        [Authorize]
        public async Task<IActionResult> AddOrder([FromForm] OrderVM OrderVM)
        {
            var ID = User.FindFirstValue("uid");
            OrderVM.APPlicationUserId=ID;
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _orderService.CreateOrderAsync(OrderVM);
            return Ok(result);
        }
        [HttpDelete("DeleteOrder")]
        [Authorize]

        public async Task<IActionResult> DeleteOrder(int OrderID)
        {
            if (OrderID > 0)
            {
                var result = await _orderService.DeleteOrderAsync(OrderID);
                return Ok(result);
            }
            return BadRequest("invalid Order");
        }
        [HttpGet("GetAllOrderGroup")]
        public async Task<IActionResult> GetAllOrderGroup(int Group)
        {
            if (Group > 0)
            {
                var result = await _orderService.GetAllOrdersAsync(Group);
                return Ok(result);
            }
            return BadRequest("Invalid");
        }
        [HttpGet("GetAllOrder")]
        public async Task<IActionResult> GetAllOrder()
        {
            var result = await _orderService.GetAllOrdersAsync();
            return Ok(result);
        }
        [HttpGet("GetOrder")]
        public async Task<IActionResult> GetOrder(int OrderID)
        {
            if (OrderID > 0)
            {
                var result = await _orderService.GetOrderAsync(OrderID);
                return Ok(result);
            }
            return BadRequest("Invalid");
        }
        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(int OrderID, [FromForm] OrderVM Order)
        {
            var ID = User.FindFirstValue("uid");
            Order.APPlicationUserId = ID;
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _orderService.UpdateOrderAsync(OrderID, Order);
            return Ok(result);
        }
    }
}
