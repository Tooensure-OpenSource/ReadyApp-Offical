using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class ProductItem
    {
        [Key]
        public Guid ProductItemId { get; private set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Product>? Products { get; set; }

        public ProductItem()
        {
            Products = new List<Product>();
        }
    }
}
