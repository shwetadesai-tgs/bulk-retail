using Microsoft.EntityFrameworkCore;
using Product.Core.Domain;
using Product.Core.IRepositories;
using Product.Core.IServices;

namespace Product.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IApplicationDbContext _context;

        public ProductRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("entity");

            return await _context.Products.FindAsync(id);
        }

        public async Task<List<ProductDto>> GetProductByNameAsync(string name)
        {
            return await _context.Products.Where(p => p.Name.Contains(name)).ToListAsync();
        }

        public async Task InsertProductAsync(ProductDto product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateProductAsync(ProductDto product)
        {
            _context.Products.Update(product);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);

            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<List<ProductDto>> GetProductsByIdsAsync(int[] productIds)
        {
            if (!productIds?.Any() ?? true)
                return new List<ProductDto>();

            var entries = await _context.Products.ToListAsync();

            //sort by passed identifiers
            var sortedEntries = new List<ProductDto>();
            foreach (var id in productIds)
            {
                var sortedEntry = entries.Find(entry => entry.Id == id);
                if (sortedEntry != null)
                    sortedEntries.Add(sortedEntry);
            }

            return sortedEntries;
        }
    }
}
