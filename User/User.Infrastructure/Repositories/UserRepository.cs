using Microsoft.EntityFrameworkCore;
using User.Core.Domain;
using User.Core.IRepositories;
using User.Core.IServices;

namespace User.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _context;

        public UserRepository(IApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);

            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> GetUserByIdAsync(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("entity");

            return await _context.Users.FindAsync(id);
        }

        public async Task<List<Users>> GetUserByNameAsync(string name)
        {
            return await _context.Users.Where(u => u.FirstName.Contains(name)).ToListAsync();
        }

        public async Task InsertUserAsync(Users user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateUserAsync(Users user)
        {
            _context.Users.Update(user);
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
