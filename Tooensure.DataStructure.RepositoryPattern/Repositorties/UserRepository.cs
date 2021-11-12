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
using Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories.ISharedRepositories;
using Tooensure.DataStructure.RepositoryPattern.Repositorties.SharedRepositories;

namespace Tooensure.DataStructure.RepositoryPattern.Repositorties
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly new DataContext _context;

        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
            Security = new AuthRepository(_context);
            
        }

        public IAuthRepository Security { get; private set; }

        public User? GetUserByEmail(string? email)
        {
            return DataContext?.Users?
                .SingleOrDefault(u => u.EmailAddress == email);
        }

        public User? GetByUsername(string username)
        {
            return DataContext?.Users?
                .SingleOrDefault(u => u.Username == username);
        }
        public ServiceResponse<string> Login(string email, string? password)
        {
            var user = GetUserByEmail(email);

            // should look something like "{response.Successful} {response.Message}, {response.Data}"
            var response = new ServiceResponse<string>(
                user?.Id.ToString(),
                VerifyPasswordHash(password, user?.PasswordHash, user?.PasswordSalt),
                "Verifing user authentication");

            return response;
        }


        public ServiceResponse<string> Add(User user, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            // User newUser = new(user) { PasswordHash = passwordHash; PasswordSalt = passwordSalt;}

            // _unitOfWork
            // .Security.Login(email, password)

            // _unitOfWork
            // .Users.Security.Register(user, password)

            // _unitOfWork
            // .Users.Authentication.Register(user, password)

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            Add(user);

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

        public DataContext? DataContext
        {
            get { return _context as DataContext; }
        }

    }
}
