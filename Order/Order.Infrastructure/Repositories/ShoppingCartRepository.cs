using Order.Core.IRepositories;
using Order.Core.ObjectModel;
using Order.Infrastructure.Repositories;

namespace Order.Infrastructure.Services
{
    public class ShoppingCartRepository : SQLRepository<ShoppingCart>, IShoppingCartRepositories
    {
        public ShoppingCartRepository(IUnitOfWork unitOfWork) : base
         (unitOfWork)
        {

        }

    }
}
