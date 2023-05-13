using Microsoft.EntityFrameworkCore;
using Order.Core.IRepositories;
using Order.Core.ObjectModel;

namespace Order.Infrastructure.Repositories
{
    public class CartRepository : SQLRepository<ShoppingCart>, ICartRepository
    {
        public CartRepository(IUnitOfWork unitOfWork) : base
            (unitOfWork)
        {

        }
    }
}
