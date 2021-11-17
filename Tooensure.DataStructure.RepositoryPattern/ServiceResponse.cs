using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tooensure.DataStructure.RepositoryPattern
{
    /// <summary>
    /// Allows a easy flow cummunication set of information to persist data flow.
    /// </summary>
    /// <typeparam name="TEntity">Defines the data in which the service response is operated on.</typeparam>
    /// <param name="Message">States the service response suspected data.</param>
    /// <param name="Data">Matches the defined data of the service response.</param>
    /// <param name="Successful">Operation boolean stating if operation successful.</param>
    public record class ServiceResponse<TEntity>(string? Message, TEntity? Data = default, bool Successful = false);
}
