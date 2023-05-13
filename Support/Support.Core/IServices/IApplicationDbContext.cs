using Microsoft.EntityFrameworkCore;
using Support.Core.Models;

namespace Support.Core.IServices
{
    public interface IApplicationDbContext
    {
        DbSet<Supports> Supports { get; set; }
        Task<int> SaveChangesAsync();
    }
}
