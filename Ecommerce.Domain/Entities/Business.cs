using Ecommerce.Domain.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooensure.Validation.Formatter;

namespace Ecommerce.Domain.Entities
{
    public class Business : EntityBase
    {
        [Key]
        public Guid BusinessId { get; private set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Username { get; set; }
        public string? Description { get; private set; }
        public string? Type { get; private set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public virtual List<Owner>? Owners { get; set; } = new List<Owner>();
        public virtual List<Employee>? Employees { get; set; } = new List<Employee>();
        public virtual List<Product> Products { get; set; } = new List<Product>();
        public virtual List<Order> Orders { get; set; } = new List<Order>();
        public Business()
        {
        }

        public Business(User? user, string name, string username)
        {
            Name = name;
            Username = username;
            Owners.Add(new Owner(user));
        }

        public override bool Validate()
        {
            var requirments = new List<bool>()
            {
                !string.IsNullOrWhiteSpace(Name),
                !string.IsNullOrWhiteSpace(Username)
            };

            foreach (var requirment in requirments)
            {
                if (requirment.Equals(false)) return false;
            }
            return true;
        }
    }
}
