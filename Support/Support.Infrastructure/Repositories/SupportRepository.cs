using Microsoft.EntityFrameworkCore;
using Support.Core;
using Support.Core.IRepositories;
using Support.Core.IServices;
using Support.Core.Models;

namespace Support.Infrastructure.Repositories
{
    public class SupportRepository : ISupportRepository
    {
        private readonly IApplicationDbContext _context;

        public SupportRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Supports>> GetAllSupportsAsync()
        {
            return await _context.Supports.ToListAsync();
        }
    }
}
