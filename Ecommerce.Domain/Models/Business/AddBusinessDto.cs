using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Models.Business
{
    public class AddBusinessDto
    {
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string Username { get; set; } = String.Empty;

    }
}