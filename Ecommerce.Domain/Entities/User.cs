using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{

    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "")]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required, EmailAddress]
        public string? EmailAddress { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; } = new byte[32];

        [Required]
        public byte[] PasswordSalt { get; set; } = new byte[] { 0 };
        
        [Required]
        public bool IsConfirmed { get; set; } = false;
        public string? Token { get; set; }
        public List<FriendList> Friends { get; set; } = new List<FriendList>();
        public List<Business> FavoriteBusinesses { get; set; } = new List<Business>();
        public User()
        {

        }
        public User(string email, string password)
        {
            EmailAddress = email;
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }


}
