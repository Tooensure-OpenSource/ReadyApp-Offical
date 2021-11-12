using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories.ISharedRepositories;

namespace Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        IAuthRepository Security { get; }
        User? GetByUsername(string username);
        User? GetUserByEmail(string email);
    }
}
