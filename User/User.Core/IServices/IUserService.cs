using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Core.Domain;

namespace User.Core.IServices
{
    public interface IUserService
    {
        /// <summary>
        /// User Authenticate
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<Users> Authenticate(string username, string password);

        /// <summary>
        /// GetAllUsersAsync 
        /// </summary>
        /// <returns></returns>
        Task<IList<Users>> GetAllUsersAsync();

        /// <summary>
        /// GetUserByIdAsync
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<Users> GetUserByIdAsync(int Id);

        /// <summary>
        /// InsertUser
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task InsertUserAsync(Users user, string password);

        /// <summary>
        /// UpdateUser
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task UpdateUserAsync(Users user, string password = null);

        /// <summary>
        /// DeleteUser
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task DeleteUserAsync(Users user);
    }
}
