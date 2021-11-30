using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories
{
    /// <summary>
    /// ( This is my beleif )
    /// Here's where i'm excersizing the second pillar of OOP "Encapsulation".
    /// eveb tho Api will be using DTO models which provides not the second pillar but the first pillar of OOP "Abstraction"
    /// GUID referance provide more security by "Encapsulating" data, mainly because there's a referance and not the full object
    /// being tranfered, now altough the server can provide more operations when having the full object
    /// allso there may be less db calls when the database has already supplied the object.
    /// I Believe Id driven repository is the way to go.
    /// There's should at least be one object return which dose allow server to operate on
    /// such as suppling the username or email
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Get referance to the user object containing username
        /// </summary>
        /// <param name="username">username referanced to user object</param>
        /// <returns>User Id if there's a user object with username</returns>
        Task<Guid?> UserIdByUsername(string username);
        /// <summary>
        /// Get referance to the user object containing email
        /// </summary>
        /// <param name="email">email referanced to user object</param>
        /// <returns>User Id if there's a user object with email</returns>
        Task<Guid?> UserIdByEmail(string email);
        /// <summary>
        /// Get referance to the user object containing email and password
        /// </summary>
        /// <param name="email">email referanced to user object</param>
        /// <param name="password">password referanced to user object</param>
        /// <returns>User Id if there's a user object with email and password</returns>
        Task<Guid?> UserIdByAuth(string email, string password);

        /// <summary>
        /// Check if data store contains user object with username
        /// </summary>
        /// <param name="username">username referancing user object</param>
        /// <returns>true if there is a user containing username else false</returns>
        Task<bool> ExistByUsername(string username);
        /// <summary>
        /// Check if data store contains user object with email
        /// </summary>
        /// <param name="email">email referancing user object</param>
        /// <returns>true if there is a user containing email else false</returns>
        Task<bool> ExistByEmail(string email);


    }
}
