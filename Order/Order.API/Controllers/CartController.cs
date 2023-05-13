using Microsoft.AspNetCore.Mvc;
using Order.Core.Helper;
using Order.Core.IServices;
using Order.Core.ObjectModel;
using Order.Core.RequestResponseModel;
using static Order.Core.Constants.Enums;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet, Route("GetAllItems/{userId}")]
        public IActionResult GetAllItems(int userId)
        {
            var cartItems = _cartService.GetAllItems(userId).Result;

            return Ok(cartItems);
        }

        [HttpPost, Route("AddCart")]
        public IActionResult AddCart(CartRequestModel cartRequestModel)
        {
            ResultMessage resultMessage = ResultMessage.Succeess;

            if (cartRequestModel == null)
            {
                return BadRequest(new APIResponseModel(null, ResultMessage.InternalServerError.GetStringValue()));
            }

            resultMessage = _cartService.Add(cartRequestModel);

            return Ok(new APIResponseModel(null, resultMessage.GetStringValue()));
        }

        [HttpPut, Route("UpdateCart")]
        public IActionResult UpdateCart(CartRequestModel cartRequestModel)
        {
            ResultMessage resultMessage = ResultMessage.Succeess;

            if (cartRequestModel == null)
            {
                return BadRequest(new APIResponseModel(null, ResultMessage.InternalServerError.GetStringValue()));
            }

            resultMessage = _cartService.Update(cartRequestModel);

            return Ok(new APIResponseModel(null, resultMessage.GetStringValue()));
        }

        [HttpDelete, Route("DeleteCart")]
        public IActionResult DeleteCart(int productId, int userId)
        {
            ResultMessage resultMessage = ResultMessage.Succeess;

            if (productId == 0 || userId == 0)
            {
                return BadRequest(new APIResponseModel(null, ResultMessage.InternalServerError.GetStringValue()));
            }

            resultMessage = _cartService.Delete(productId, userId);

            return Ok(new APIResponseModel(null, resultMessage.GetStringValue()));
        }
    }
}
