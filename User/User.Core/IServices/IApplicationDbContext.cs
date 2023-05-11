using Microsoft.EntityFrameworkCore;
using User.Core.Domain;

namespace User.Core.IServices
{
    public interface IApplicationDbContext
    {
        DbSet<Users> Users { get; set; }
        Task<int> SaveChangesAsync();
    }
}
