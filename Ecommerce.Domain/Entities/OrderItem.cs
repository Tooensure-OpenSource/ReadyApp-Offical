using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class OrderItem
    {
        [Key]
        public Guid OrderItemId { get; private  set; }

        public int Quantity { get; set; } = 1;
        public Guid OrderId { get; set; }
        [Required]
        public Order? Order { get; set; }
        public Guid ProductId { get; set; }
        [NotMapped]
        public Product? Product { get; set; }

    }
}
