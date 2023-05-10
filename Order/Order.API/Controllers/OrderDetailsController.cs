using Microsoft.AspNetCore.Mvc;
using Order.Core.IServices;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailServices _orderDetailServices;
        public OrderDetailsController(IOrderDetailServices orderDetailServices)
        {
            _orderDetailServices = orderDetailServices;
        }

        [HttpGet, Route("GetAllOrderDetails/{orderId}")]
        public async Task<IActionResult> GetAllOrders(int orderId)
        {
            var orders = await _orderDetailServices.GetAllOrders(orderId);

            return Ok(orders);
        }

    }
}
