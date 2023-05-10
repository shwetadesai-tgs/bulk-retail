using Microsoft.EntityFrameworkCore;
using Product.Core.Domain;

namespace Product.Core.IServices
{
    public interface IApplicationDbContext
    {
        DbSet<ProductDto> Products { get; set; }
        Task<int> SaveChangesAsync();
    }
}
