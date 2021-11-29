using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUsername(string username);
        Task<User?> GetByUserEmail(string email);
        Task<User?> GetUserByAuth(string email, string password);
        Task<bool> ExistByUsername(string username);
        Task<bool> ExistByEmail(string email);
    }
}
