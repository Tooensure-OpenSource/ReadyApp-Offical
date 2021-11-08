using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Business
    {
        [Key]
        public Guid BusinessId { get; private set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Username { get; private set; }
        public string? Description { get; private set; }
        public string? Type { get; private set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public List<Owner>? Owners { get; set; }
        public List<Employee>? Employees { get; set; }
        public List<Product>? Products { get; set; }
        public List<Order>? Orders { get; set; }

        public Business()
        {
            Owners = new List<Owner>();
            Employees = new List<Employee>();
            Products = new List<Product>();
            Orders = new List<Order>();
        }


        public Business(User user) => Owners.Add(new Owner(user));

        // Not sure if nessecary
        public int OwnerCount() { return Owners.Count(); }
        public int EmployeeCount() { return Owners.Count(); }
        public int ProductCount() { return Owners.Count(); }
        public int OrderCount() { return Owners.Count(); }
    }
}
