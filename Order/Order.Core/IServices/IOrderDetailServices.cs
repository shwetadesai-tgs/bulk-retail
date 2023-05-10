using Order.Core.ObjectModel;

namespace Order.Core.IServices
{
    public interface IOrderDetailServices
    {
        Task<List<OrderDetails>> GetAllOrders(int userId);
        OrderDetails GetOrder(int orderId);

    }
}
