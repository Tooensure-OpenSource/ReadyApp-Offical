using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities.Bases
{
    public abstract class UserBase
    {

        [NotMapped]
        public List<KeyValuePair<string, bool>> IsValid => Validate();

        public abstract List<KeyValuePair<string, bool>> Validate();
    }
}
