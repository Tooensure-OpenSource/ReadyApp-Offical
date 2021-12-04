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


        public async Task<User?> FindByEmail(string email)
        {
            var emailExist = await ExistByEmail(email);
            User? response;

            if (DataContext?.Users != null && emailExist)
            {
                response = await DataContext.Users.SingleOrDefaultAsync(u => u.EmailAddress == email);
                return response;
            }
            return null;
        }

        public async Task<User?> FindByUsername(string username)
        {
            var usernameExist = await ExistByUsername(username);
            User? response;

            if (DataContext?.Users != null && usernameExist)
            {
                response = await DataContext.Users.SingleOrDefaultAsync(u => u.Username == username);
                return response;
            }
            return null;
        }
        public async Task<User?> UserIdByAuth(string email,string password)
        {
            var validEmail = await ExistByEmail(email);
            User? response;
            if (DataContext?.Users != null && validEmail)
            {
                response = await DataContext.Users.SingleOrDefaultAsync(u => u.EmailAddress == email);
                    if (VerifyPasswordHash(password, response.PasswordHash, response.PasswordSalt))
                        // Issuing Token
                        return response;
            }
            return null;
        }
        public async Task<bool> ExistByUsername(string username)
        {
            if (DataContext?.Users != null)
                return await DataContext.Users.AnyAsync(u => u.Username == username);
            return false;
        }

        public async Task<bool> ExistByEmail(string? email)
        {
            if (DataContext?.Users != null)
                return await DataContext.Users.AnyAsync(u => u.EmailAddress == email);
            return false;
        }

        public DataContext? DataContext
        {
            get => _context as DataContext ?? throw new ArgumentNullException(nameof(_context));
        }

        
    }
}
