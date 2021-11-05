using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories.IRepositories.IUserRepositories
{
    public interface IUserAuthRepository
    {
        bool UserExist();
        bool UserExistByUsername(string username);
        bool UserExistByEmail(string email);
    }
}
