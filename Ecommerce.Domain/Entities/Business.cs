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
        public virtual List<Employee>? Employees { get; set; }
        public virtual List<Product>? Products { get; set; }
        public virtual List<Order>? Orders { get; set; }
        public List<User> Consumers { get; set; }
        public Business()
        {
            Owners = new List<Owner>();
            Employees = new List<Employee>();
            Products = new List<Product>();
            Orders = new List<Order>();
            Consumers = new List<User>();
        }
        public Business(Guid businessId)
        {
            BusinessId = businessId;
        }
        public Business(User user, Business business)
        {
            Name = business.Name;
            Username = business.Username;
            Description = business.Description;
            Type = business.Type;
            CreatedDate = business.CreatedDate;
            Owners.Add(new Owner(user));
        }

        public Business(User user) => Owners.Add(new Owner(user));

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

        // Not sure if nessecary
        public int OwnerCount() { return Owners.Count(); }
        public int EmployeeCount() { return Owners.Count(); }
        public int ProductCount() { return Owners.Count(); }
        public int OrderCount() { return Owners.Count(); }
    }
}
