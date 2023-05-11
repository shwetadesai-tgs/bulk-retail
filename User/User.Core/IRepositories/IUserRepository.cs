using User.Core.Domain;

namespace User.Core.IRepositories
{
    public interface IUserRepository
    {
        Task<List<Users>> GetAllUsersAsync();
        Task<Users> GetUserByIdAsync(int id);
        Task<List<Users>> GetUserByNameAsync(string name);
        Task InsertUserAsync(Users user);
        Task<bool> UpdateUserAsync(Users user);
        Task<bool> DeleteUserAsync(int id);
    }
}
