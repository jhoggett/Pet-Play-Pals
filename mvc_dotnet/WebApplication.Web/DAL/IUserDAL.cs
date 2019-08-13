using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.DAL
{
    public interface IUserDAL
    {
        /// <summary>
        /// Retrieves a user from the system by username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        User GetUser(string username);

        User GetUserById(int id);

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user"></param>
        void CreateUser(User user);

        /// <summary>
        /// Updates a user's email
        /// </summary>
        /// <param name="user"></param>
        void UpdateUserEmail(User user);

        /// <summary>
        /// Updates a user's password
        /// </summary>
        /// <param name="user"></param>
        void UpdateUserPassword(User user);

        /// <summary>
        /// Updates a user's first name
        /// </summary>
        /// <param name="user"></param>
        void UpdateUserFirstName(User user);

        /// <summary>
        /// Updates a user's last name
        /// </summary>
        /// <param name="user"></param>
        void UpdateUserLastName(User user);
    }
}
