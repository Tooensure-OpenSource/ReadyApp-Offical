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

        public UserRepository(DataContext context) : base(context) {}


        public async Task<User?> GetByUserEmail(string email)
        {
            var emailExist = ExistByEmail(email);

            if (DataContext?.Users != null)
                return await DataContext.Users.SingleOrDefaultAsync(u => u.EmailAddress == email);
            return null;
        }

        public async Task<User?> GetByUsername(string username)
        {
            var usernameExist = ExistByUsername(username);

            if (DataContext?.Users != null)
                return await DataContext.Users.SingleOrDefaultAsync(u => u.Username == username);
            return null;
        }
        public async Task<User?> GetUserByAuth(string email,string password)
        {
            var user = GetByUserEmail(email);

            if (user?.Result != null && VerifyPasswordHash(password, user.Result.PasswordHash, user.Result.PasswordSalt))
            {
                return await user;
            }


            return null;
        }

        public DataContext? DataContext
        {
            get => _context as DataContext ?? throw new ArgumentNullException(nameof(_context));
        }

        public async Task<bool> ExistByUsername(string username)
        {
            if (DataContext?.Users != null)
                return await DataContext.Users.AnyAsync(u => u.Username == username);
            return false;
        }

        public async Task<bool> ExistByEmail(string email)
        {
            if (DataContext?.Users != null)
                return await DataContext.Users.AnyAsync(u => u.EmailAddress == email);
            return false;
        }
    }
}
