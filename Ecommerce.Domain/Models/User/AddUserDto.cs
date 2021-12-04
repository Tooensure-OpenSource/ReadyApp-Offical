using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Models.User
{
    public class AddUserDto
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required, EmailAddress]
        public string? EmailAddress { get; set; }

    }
}
