using Ecommerce.Domain.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public static class PasswordHahing
    {
        public static void PasswordHahin(string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }

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
        public byte[]? PasswordHash { get; set; }

        [Required]
        public byte[]? PasswordSalt { get; set; }
        
        [Required]
        public bool IsConfirmed { get; set; } = false;

        public User()
        {

        }
        public User(string password)
        {
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
