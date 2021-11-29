using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class FriendList
    {
        [Key]
        public Guid Id { get; set; }
        public List<User>? Users { get; set; }
    }


}
