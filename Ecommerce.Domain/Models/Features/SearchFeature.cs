using Ecommerce.Domain.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Models.Features
{
    public class SearchFeature : EntityBase
    {
        public string? Username { get; private set; }
        public SearchFeature() { }
        public SearchFeature(string username)
        {
            Username = username;
        }

        public override bool Validate()
        {
            return !string.IsNullOrEmpty(Username);
        }
       
    }
}
