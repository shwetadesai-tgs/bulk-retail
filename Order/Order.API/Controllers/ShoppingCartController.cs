using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Core.IServices;
using Order.Core.RequestResponseModel;
using static Order.Core.Constants.Enums;
using Order.Core.Helper;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpPost, Route("AddProductToCart")]
        public virtual IActionResult AddProductToCart(int productId, int quantity, int userId)
        {
            ResultMessage resultMessage = ResultMessage.Succeess;

            resultMessage = _shoppingCartService.AddtProductToCart(productId, quantity, userId);

            return Ok(new APIResponseModel(null, resultMessage.GetStringValue()));
        }
    }
}
