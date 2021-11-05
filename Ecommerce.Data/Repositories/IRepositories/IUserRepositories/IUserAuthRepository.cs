using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories.IRepositories.IUserRepositories
{
    public interface IUserAuthRepository
    {
        void Register(User user);
        ServiceResponse<Guid> Login(Guid id);

        /// <summary>
        /// Check if user exist based on other user exist medthods
        /// </summary>
        /// <returns>True if user exist</returns>
        bool UserExist();

        /// <summary>
        /// Check if there is a user withing the data store with param
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if user in data store contains Guid</returns>
        bool UserExistById(Guid id);

        /// <summary>
        /// Check if there is a user withing the data store with param
        /// </summary>
        /// <param name="username"></param>
        /// <returns>True if user in data store contains username</returns>
        bool UserExistByUsername(string username);

        /// <summary>
        /// Check if there is a user withing the data store with param
        /// </summary>
        /// <param name="email"></param>
        /// <returns>True if user in data store contains email</returns>
        bool UserExistByEmail(string email);
    }
}
