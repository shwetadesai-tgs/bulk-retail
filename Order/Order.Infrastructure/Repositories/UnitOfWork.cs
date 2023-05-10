using Order.Core;
using Order.Core.IRepositories;

namespace Order.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public DatabaseContext DatabaseContext;

        DatabaseContext IUnitOfWork.databaseContext { get => DatabaseContext; set => throw new NotImplementedException(); }
        public UnitOfWork(DatabaseContext context)
        {
            DatabaseContext = context;
        }


        public virtual void Commit()
        {
            DatabaseContext.SaveChanges();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
