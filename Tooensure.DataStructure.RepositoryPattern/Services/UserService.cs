using System.Security.Cryptography;
using Ecommerce.Domain.Entities;
using Tooensure.DataStructure.RepositoryPattern.Repositorties;

namespace Tooensure.DataStructure.RepositoryPattern.Services.IService
{
    public class UserService : RepositoryService<User>, IUserService
    {
        private readonly UserRepository _user;

        public UserService(UserRepository user)
        {
            _user = user;
        }
        public async override Task<IEnumerable<User?>?> All(Guid? id = null)
        {
            return await _user.GetAll();
        }

        // public async override Task<User?> Get(Guid id1, Guid? id2 = null)
        // {
        //     return await _user.FindById(id1);
        // }

        public async override Task<User?> Create(User user)
        {
            return await _user.Add(user);
        }

        public async override Task<User?> Get(Guid userId)
        {
            var token = new KeyValuePair<Guid,Guid?>(userId, null);

            return await _user.FindById(token.Key);
        }

        public override Task<User?> Get(Guid id1, Guid id2)
        {
            throw new NotImplementedException();
        }
    }
}




        // public async Task<User?> Login(string email, string password)
        // {
        //     var user = await _user.FindByEmail(email);
        //     if (user == null) return null;
        //     if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) return null;
        //     return user;
        // }

        // public Task<User?> LoginOut(string token)
        // {
        //     throw new NotImplementedException();
        // }

        // public async Task<User?> SignUp(User? user)
        // {
        //     if (user == null) return null;
        //     if (await _user.ExistByEmail(user.EmailAddress)) return null;
        //     _user.Add(user);
        //     return user;
        // }

        // private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        // {
        //     using (var hmac = new HMACSHA512(passwordSalt))
        //     {
        //         var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        //         for (int i = 0; i < computedHash.Length; i++)
        //         {
        //             if (computedHash[i] != passwordHash[i])
        //             {
        //                 return false;
        //             }
        //         }
        //         return true;
        //     }
        // }