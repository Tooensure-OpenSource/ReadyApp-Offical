using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories.ISharedRepositories
{
    public interface IAuthRepository
    {
        ServiceResponse<string> RegisterAsUser(User user, string password);
        ServiceResponse<string> LoginAsUser(string email, string password);
    }
}
