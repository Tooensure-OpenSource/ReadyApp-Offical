using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Owner
    {
        [Key]
        public Guid OwnerId { get; private set; }

        [Required(ErrorMessage = "Ownership is required")]
        public decimal Ownerhship { get; set; } = 100;
        public string? Name { get; private set; }

        public Guid BusinessId { get; set; }
        public Business? Business { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Owner() { }
        public Owner(User user)
        {
            User = user;
            Name = $"{user.FirstName} {user.LastName}";
        }
    }
}
