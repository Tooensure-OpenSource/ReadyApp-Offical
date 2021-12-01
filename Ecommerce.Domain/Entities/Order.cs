using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Order
    {

        [Key]
        public Guid Id { get; private set; }
        public DateTime dateTime { get; private set; } = DateTime.Now;
        [Required]
        public bool IsReady { get; set; } = false;
        public decimal TotalCost { get; set; }
        public bool Canceled { get; set; } = false;

        public List<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid BusinessId { get; set; }
        public Business? Business { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
