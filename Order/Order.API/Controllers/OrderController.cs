using Microsoft.AspNetCore.Mvc;
using Order.Core.Helper;
using Order.Core.IServices;
using Order.Core.RequestResponseModel;
using System.Net;
using static Order.Core.Constants.Enums;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderServices;
        public OrderController(IOrderService orderServices)
        {
            _orderServices = orderServices;
        }
        [HttpGet, Route("GetAllOrders/{userId}")]
        public IActionResult GetAllOrders(int userId)
        {
            var orders = _orderServices.GetAllOrders(userId).Result;

            return Ok(orders);
        }


        [HttpGet("{id}")]
        public IActionResult GetOrder(int orderId)
        {
            var order = _orderServices.GetOrder(orderId);

            return order != null ? Ok(order) : NotFound();
        }

        [HttpPost, Route("AddOrder")]
        public IActionResult AddOrder(OrderRequestModel orderRequestModel)
        {
            ResultMessage resultMessage = ResultMessage.Succeess;

            if (orderRequestModel == null)
            {
                return BadRequest(new APIResponseModel(null, ResultMessage.InternalServerError.GetStringValue()));
            }

            resultMessage = _orderServices.Add(orderRequestModel);

            return Ok(new APIResponseModel(null, resultMessage.GetStringValue()));
        }

        [HttpPut, Route("UpdateOrder")]
        public IActionResult UpdateOrder(OrderRequestModel orderRequestModel)
        {
            ResultMessage resultMessage = ResultMessage.Succeess;

            if (orderRequestModel == null)
            {
                return BadRequest(new APIResponseModel(null, ResultMessage.InternalServerError.GetStringValue()));
            }
            return Ok(new APIResponseModel(null, resultMessage.GetStringValue()));
        }
        [HttpGet, Route("OrderStatus/{id}")]
        public IActionResult OrḍerStatus(int id)
        {
            return Ok(_orderServices.GetOrder(id).OrderStatus);
        }
        [HttpDelete, Route("DeleteOrder")]
        public IActionResult DeleteOrder(int orderId)
        {
            ResultMessage resultMessage = ResultMessage.Succeess;

            if (orderId == 0)
            {
                return BadRequest(new APIResponseModel(null, ResultMessage.InternalServerError.GetStringValue()));
            }

            resultMessage = _orderServices.Delete(orderId);

            return Ok(new APIResponseModel(null, resultMessage.GetStringValue()));
        }
    }
}
