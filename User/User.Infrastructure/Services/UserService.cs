using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;
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

        public async Task<Users> Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var users = await _userRepository.GetUserByEmailAsync(email);

            // check if password is correct
            if (!VerifyPasswordHash(password, users.PasswordHash, users.PasswordSalt))
                return null;

            // authentication successful
            return users;
        }

        public async Task<IList<Users>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<Users> GetUserByIdAsync(int Id)
        {
            return await _userRepository.GetUserByIdAsync(Id);
        }

        public async Task InsertUserAsync(Users user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("Password is required");

            var users = await _userRepository.GetAllUsersAsync();
            if (users.Any(x => x.FirstName == user.FirstName))
                throw new ArgumentNullException("Name \"" + user.FirstName + "\" is already taken");

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _userRepository.InsertUserAsync(user);
        }

        public async Task UpdateUserAsync(Users userParam, string password = null)
        {
            var user = await _userRepository.GetUserByIdAsync(userParam.Id);

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.FirstName) && userParam.FirstName != user.FirstName)
            {
                // throw error if the new Name is already taken
                var users = await _userRepository.GetUserByNameAsync(user.FirstName);
                if (users.Any(x => x.FirstName == user.FirstName))
                    throw new ArgumentNullException("Name \"" + user.FirstName + "\" is already taken");

                user.Email = userParam.Email;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
                user.FirstName = userParam.FirstName;

            if (!string.IsNullOrWhiteSpace(userParam.LastName))
                user.LastName = userParam.LastName;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(Users user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("entity");
            }

            await _userRepository.DeleteUserAsync(user.Id);
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (password == null)
                throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}
