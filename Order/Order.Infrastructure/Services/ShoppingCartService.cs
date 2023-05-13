using Order.Core.IRepositories;
using Order.Core.IServices;
using Order.Core.ObjectModel;
using Product.Core.IServices;
using static Order.Core.Constants.Enums;

namespace Order.Infrastructure.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IProductServices _productServices;
        private readonly IShoppingCartRepositories _shoppingCartRepositories;
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartService(IProductServices productServices, IShoppingCartRepositories shoppingCartRepositories, IUnitOfWork unitOfWork)
        {
            _productServices = productServices;
            _shoppingCartRepositories = shoppingCartRepositories;
            _unitOfWork = unitOfWork;
        }

        public ResultMessage AddtProductToCart(int productId, int quantity, int userId)
        {
            ResultMessage resultMessage = ResultMessage.Succeess;

            var product = _productServices.GetProductByIdAsync(productId);

            if (product == null)
            {
                resultMessage = ResultMessage.RecorNotFound;

                return resultMessage;
            }
            var existShoppingCartItem = FindShoppingCartItemInCart(productId, userId);
            if (existShoppingCartItem == null)
            {
                var cart = new ShoppingCart()
                {
                    ProductId = productId,
                    UserId = userId,
                    Qty = quantity,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                };
                _shoppingCartRepositories.Create(cart);
                _unitOfWork.Commit();
            }
            else
            {
                existShoppingCartItem.Qty = existShoppingCartItem.Qty + quantity;
                existShoppingCartItem.UpdatedDate = DateTime.UtcNow;
                _shoppingCartRepositories.Update(existShoppingCartItem);
                _unitOfWork.Commit();
            }
            return resultMessage;
        }

        private ShoppingCart FindShoppingCartItemInCart(int productId, int userId)
        {
            var shoppingCart = _shoppingCartRepositories.Find(x => x.ProductId == productId && x.UserId == userId).First();
            return shoppingCart;
        }
    }
}
