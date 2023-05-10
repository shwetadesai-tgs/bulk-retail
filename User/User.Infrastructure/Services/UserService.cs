using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Core.Domain;
using User.Core.IServices;

namespace User.Infrastructure.Services
{
    public class UserService : IUserService
    {
        public Task DeleteUserAsync(Users user)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Users>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetUserByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task InsertUserAsync(Users user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
