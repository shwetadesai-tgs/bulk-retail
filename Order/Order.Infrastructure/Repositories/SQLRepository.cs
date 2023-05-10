using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Order.Core;
using Order.Core.IRepositories;
using System.Linq.Expressions;

namespace Order.Infrastructure.Repositories
{
    public class SQLRepository<T> : ISQLRepository<T> where T : class
    {
        protected DatabaseContext databaseContext;

        public SQLRepository(IUnitOfWork uow)
        {
            databaseContext = uow.databaseContext;
        }
        protected DbSet<T> DbSet
        {
            get
            {
                return databaseContext.Set<T>();
            }
        }

        public virtual IQueryable<T> All()
        {
            return DbSet.AsQueryable();
        }
        public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.AsQueryable();
        }
        
        public virtual EntityEntry<T> Create(T T)
        {
            var newEntry = DbSet.Add(T);
            return newEntry;
        }

        public virtual int Update(T T)
        {
            var entry = databaseContext.Entry(T);
            DbSet.Attach(T);
            entry.State = EntityState.Modified;
            return 0;
        }
    }
}
