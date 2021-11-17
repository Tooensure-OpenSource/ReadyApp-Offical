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
        ServiceResponse<User> GetByUsername(string username);
        ServiceResponse<User> GetByUserEmail(string email);
        ServiceResponse<string> GetByUser(string email, string password);

        void PurgeDatabase();
        bool ExistByUsername(string username);
        bool ExistByEmail(string email);
    }
}
