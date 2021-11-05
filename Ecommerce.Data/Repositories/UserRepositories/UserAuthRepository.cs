using Ecommerce.Data.Repositories.IRepositories.IUserRepositories;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories.UserRepositories
{
    public class UserAuthRepository : IUserAuthRepository
    {
        private readonly DataContext _dataContext;

        public UserAuthRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ServiceResponse<Guid> Login(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Register(User user)
        {
            throw new NotImplementedException();
        }

        public bool UserExist()
        {
            throw new NotImplementedException();
        }

        public bool UserExistByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool UserExistById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool UserExistByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
