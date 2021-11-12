using Ecommerce.Domain.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class User : UserBase
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


        public override bool Validate()
        {
            var requirments = new Dictionary<string, bool>();

            requirments.Add("First name Required", string.IsNullOrWhiteSpace(FirstName));
            requirments.Add("Last name Required", string.IsNullOrWhiteSpace(LastName));

            requirments.Add("Username Required", string.IsNullOrWhiteSpace(Username));
            requirments.Add("Email Address Required", string.IsNullOrWhiteSpace(EmailAddress));

            foreach (var item in requirments)
            {
                if (item.Value.Equals(true)) return false;
            }
            return true;
        }
    }
}
