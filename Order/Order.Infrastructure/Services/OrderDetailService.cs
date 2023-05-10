using Order.Core.IRepositories;
using Order.Core.IServices;
using Order.Core.ObjectModel;

namespace Order.Infrastructure.Services
{
    public class OrderDetailService : IOrderDetailServices
    {
        private readonly IOrderDetailRepositories _orderDetailRepositories;
        public OrderDetailService(IOrderDetailRepositories orderDetailRepositories)
        {
            _orderDetailRepositories = orderDetailRepositories;
        }

        public async Task<List<OrderDetails>> GetAllOrders(int userId)
        {
            try
            {
                return _orderDetailRepositories.Find(x => x.OrderId == userId).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public OrderDetails GetOrder(int orderId)
        {
            try
            {
                return _orderDetailRepositories.Find(x => x.OrderId == orderId).First();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
