namespace Order.Core.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        DatabaseContext databaseContext { get; set; }
        void Commit();
    }
}
