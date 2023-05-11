using User.Core.Domain;
using User.Core.IRepositories;
using User.Core.IServices;

namespace User.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task DeleteUserAsync(Users user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("entity");
            }

            await _userRepository.DeleteUserAsync(user.Id);
        }

        public async Task<IList<Users>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<Users> GetUserByIdAsync(int Id)
        {
            return await _userRepository.GetUserByIdAsync(Id);
        }

        public async Task InsertUserAsync(Users user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await _userRepository.InsertUserAsync(user);
        }

        public async Task UpdateUserAsync(Users user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await _userRepository.UpdateUserAsync(user);
        }
    }
}
