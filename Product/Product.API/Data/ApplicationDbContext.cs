using Microsoft.EntityFrameworkCore;
using Product.Core.Domain;
using Product.Core.IServices;

namespace BulkRetail.ProductService.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<ProductDto> Products { get; set; }
    }
}
