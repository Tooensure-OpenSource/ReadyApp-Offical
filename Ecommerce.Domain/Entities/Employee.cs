using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Employee
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        public string? Name { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }



    }
}
