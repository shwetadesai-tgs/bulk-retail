using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Order.Core.IRepositories
{
    public interface ISQLRepository<T> where T : class
    {
        IQueryable<T> All();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        EntityEntry<T> Create(T T);
        int Update(T T);
    }
}
