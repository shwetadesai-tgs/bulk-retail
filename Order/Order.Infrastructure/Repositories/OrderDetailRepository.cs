using Order.Core.IRepositories;
using Order.Core.ObjectModel;

namespace Order.Infrastructure.Repositories
{
    public class OrderDetailRepository : SQLRepository<OrderDetails>, IOrderDetailRepositories
    {
        public OrderDetailRepository(IUnitOfWork unitOfWork) : base
            (unitOfWork)
        { }
    }
}
