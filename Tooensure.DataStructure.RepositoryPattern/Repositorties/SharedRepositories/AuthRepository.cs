using Ecommerce.Data;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories.ISharedRepositories;

namespace Tooensure.DataStructure.RepositoryPattern.Repositorties.SharedRepositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext context;

        public AuthRepository(DataContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        private User? GetUserByEmail(string? email)
        {
            return context.Users?.SingleOrDefault(u => u.EmailAddress == email);
        }

        public ServiceResponse<string> LoginAsUser(string email, string? password)
        {
            var user = GetUserByEmail(email);

            return new ServiceResponse<string>(
                user?.Id.ToString(),
                VerifyPasswordHash(password, user?.PasswordHash, user?.PasswordSalt),
                "Verifing user authentication");

        }

        public ServiceResponse<string> RegisterAsUser(User? user, string password)
        {
            if (GetUserByEmail(user?.EmailAddress) != null) return new ServiceResponse<string>(successful: false);

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            // User newUser = new(user) { PasswordHash = passwordHash; PasswordSalt = passwordSalt;}

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            context.Users.Add(user);
            context.SaveChanges();


            var response = new ServiceResponse<string>(
                user.Id.ToString(),
                VerifyPasswordHash(password, user?.PasswordHash, user?.PasswordSalt),
                "User has been created");

            return response;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

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
    }
}
