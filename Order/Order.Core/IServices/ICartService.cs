using Order.Core.ObjectModel;
using Order.Core.RequestResponseModel;
using static Order.Core.Constants.Enums;

namespace Order.Core.IServices
{
    public interface ICartService
    {
        Task<List<ShoppingCart>> GetAllItems(int userId);
        ResultMessage Update(CartRequestModel cartRequestModel);
        ResultMessage Add(CartRequestModel cartRequestModel);
        ResultMessage Delete(int productId, int userId);
    }
}

