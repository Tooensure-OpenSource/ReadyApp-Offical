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

        public bool UserExist(User user)
        {
            return UserExistById(user.Id) || UserExistByEmail(user.EmailAddress) || UserExistByUsername(user.Username);
        }

        public bool UserExistByEmail(string email)
        {
            // There shouldn't ever be a case where data store has a empty/null email (email required)
            if (string.IsNullOrWhiteSpace(email)) return false;

            // Access data store and check if there's a user containing email
            return _dataContext.Users.Any(u => u.EmailAddress == email);
        }

        public bool UserExistById(Guid id)
        {
            // Access data store and check if there's a user containing username
            return _dataContext.Users.Any(u => u.Id == id);
        }

        public bool UserExistByUsername(string username)
        {
            // There shouldn't ever be a case where data store has a empty/null username (username required)
            if (string.IsNullOrWhiteSpace(username)) return false;

            // Access data store and check if there's a user containing username
            return _dataContext.Users.Any(u => u.Username == username);
        }
    }
}
