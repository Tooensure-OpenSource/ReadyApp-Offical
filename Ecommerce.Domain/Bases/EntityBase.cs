using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Bases
{
    public class EntityBase
    {
        public bool IsValid => Validate();
        public virtual bool Validate()
        {
            return true;
        }
    }
}
