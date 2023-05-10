using Order.Core.ObjectModel;
using Order.Core.RequestResponseModel;
using static Order.Core.Constants.Enums;

namespace Order.Core.IServices
{
    public interface IOrderService
    {
        Task<List<Orders>> GetAllOrders(int userId);
        Orders GetOrder(int orderId);
        ResultMessage Update(OrderRequestModel orderRequestModel);
        ResultMessage Add(OrderRequestModel orderRequestModel);
    }
}
