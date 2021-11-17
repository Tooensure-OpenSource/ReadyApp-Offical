using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Models
{
    public record class Login(string serverUrl,string email, string password)
    {
        public string Token { get; set; }
    };
}
