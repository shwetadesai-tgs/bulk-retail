using static Order.Core.Constants.Enums;

namespace Order.Core.IServices
{
    public interface IShoppingCartService
    {
        ResultMessage AddtProductToCart(int productId, int quantity, int userId);
    }
}
