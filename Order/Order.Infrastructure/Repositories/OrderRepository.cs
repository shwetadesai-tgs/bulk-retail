using Order.Core.IRepositories;
using Order.Core.ObjectModel;

namespace Order.Infrastructure.Repositories
{
    public class OrderRepository : SQLRepository<Orders>, IOrderRepositories
    {
        public OrderRepository(IUnitOfWork unitOfWork) : base
            (unitOfWork)
        {

        }
    }
}
