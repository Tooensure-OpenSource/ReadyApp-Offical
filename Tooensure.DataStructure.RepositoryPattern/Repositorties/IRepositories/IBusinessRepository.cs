using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories
{
    public interface IBusinessRepository : IRepository<Business>
    {
        /// <summary>
        /// Search business by username and return a service response of type business
        /// </summary>
        /// <param name="username">A business with this username</param>
        /// <returns>A business with specified username</returns>
        ServiceResponse<Business> GetBusinessByUsername(string username);

    }
}
