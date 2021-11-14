using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tooensure.DataStructure.RepositoryPattern
{
    public record class ServiceResponse<TEntity>(string? Message, TEntity? Data = default, bool Successful = false);
}
