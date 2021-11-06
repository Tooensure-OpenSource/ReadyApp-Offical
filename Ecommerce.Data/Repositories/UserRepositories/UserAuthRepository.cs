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

        public ServiceResponse<string> Login(string email, string password)
        {
            var response = new ServiceResponse<string>() { Data = string.Empty };
            var user = _dataContext.Users.FirstOrDefault(u => u.EmailAddress.ToLower().Equals(email.ToLower()));

            if (user == null)
            {
                response.IsSuccessful = false;
                response.Message = "User not found";
                return response;
            }
            else if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.IsSuccessful = false;
                response.Message = "Wrong Password";
                return response;
            }
            else
            {
                response.Data = user.Id.ToString();
            }
            return response;
        }

        public ServiceResponse<Guid> Register(User user, string password)
        {
            var response = new ServiceResponse<Guid>();
            // First check if user exist before proceeding
            if (UserExist(user))
            {
                response.IsSuccessful = false;
                response.Message = "User already Exist";
                return response;
            }

            createPasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            // Adding user to data store
            _dataContext.Users.AddAsync(user);
            _dataContext.SaveChangesAsync();

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
            return _dataContext.Users.Any(u => u.EmailAddress.ToLower().Equals(email.ToLower()));
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
            return _dataContext.Users.Any(u => u.Username.ToLower().Equals(username.ToLower()));
        }

        private void createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
