using Ecommerce.Data;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories;

namespace Tooensure.DataStructure.RepositoryPattern.Repositorties
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private bool VerifyPasswordHash(string? password, byte[]? passwordHash, byte[]? passwordSalt)
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

        public UserRepository(DataContext context) : base(context) {}


        public ServiceResponse<User> GetByUserEmail(string email)
        {
            var emailExist = ExistByEmail(email);

            return 
                new(
                    Data: DataContext?.Users?.SingleOrDefault(u => u.EmailAddress == email),
                    Successful: emailExist,
                    Message: $"[Email Exist {emailExist}]");
        }

        public ServiceResponse<User> GetByUsername(string username)
        {
            var usernameExist = ExistByUsername(username);

            return
                new(
                    Data: DataContext?.Users?.SingleOrDefault(u => u.Username == username),
                    Successful: usernameExist,
                    Message: $"[Username Exist {usernameExist}]");
        }

        public ServiceResponse<string> GetByUser(string email,string password)
        {
            var user = GetByUserEmail(email);

            var validation = VerifyPasswordHash(password, user?.Data?.PasswordHash, user?.Data?.PasswordSalt);
            return 
                new(
                    Data: user?.Data?.Id.ToString(), 
                    Successful: validation,
                    Message: $" ~ [Validation {validation}], [{user?.Message}]");

        }
        public override ServiceResponse<string> Add(User entity)
        {
            var user =  base.Add(entity);

            return
                new(
                    Data: entity.Id.ToString(),
                    Successful: user.Successful,
                    Message: $" ~ [Validation {user.Successful}], [{user?.Message}]");

        }
        public DataContext? DataContext
        {
            get => _context as DataContext;
        }

        public bool ExistByUsername(string username)
        {
            return DataContext?.Users?.Any(u => u.Username == username) ?? throw new ArgumentNullException(nameof(username));
        }

        public bool ExistByEmail(string email)
        {
            return DataContext?.Users?.Any(u => u.EmailAddress == email) ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
