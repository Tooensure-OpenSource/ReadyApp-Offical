using Ecommerce.Data.Repositories.IRepositories.IUserRepositories;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public async Task<ServiceResponse<Guid>> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<Guid>> Register(User user, string password)
        {
            var response = new ServiceResponse<Guid>();
            // First check if user exist before proceeding
            if (UserExist(user))
            {
                response.IsSuccessful = false;
                return response;
            }

            createPasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            // Adding user to data store
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            response.Data = user.Id;
            return response;
            
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

        private void createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
