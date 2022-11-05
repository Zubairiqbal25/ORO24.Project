using Inlogic.Pos.Entities;
using Inlogic.Services.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inlogic.PosSolution.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderservice;

        public OrderController(IOrderService orderservice)
        {
            _orderservice = orderservice;
        }
        [HttpGet]
        [Route("OrderList")]
        public async Task<IActionResult> OrderList()
        {
            try
            {
                var Result = await _orderservice.getOrders();
                return Ok(Result);
            }
            catch (Exception) { throw; }
        }

        [HttpPost]
        [Route("GetOrderById")]
        public async Task<IActionResult> getOrderById(Guid id)
        {
            try
            {
                var Result = await _orderservice.getOrderById(id);
                return Ok(Result);
            }
            catch (Exception) { throw; }
        }

        [HttpPost]
        [Route("PlaceOrder")]
        public async Task<IActionResult> PlaceOrder(Order data)
        {
            try
            {
                var Result = await _orderservice.PlaceOrder(data);
                return Ok(Result);
            }
            catch (Exception)
            {
                throw;
            }
           
        }

    }
}
