using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; private set; }

        [Required]
        public string? Name {  get; private set; } 
        
        public string? Description { get; set; }

        public decimal PriceTag { get; set; }
        [Required]
        public Guid BusinessId { get; set; }
        public List<ProductItem>? ProductItems { get; set; }

        /// <summary>
        /// On product create/initulization, also create/initulize list of product items
        /// </summary>
        public Product()
        {
            ProductItems = new List<ProductItem>();
        }
        
    }
}

