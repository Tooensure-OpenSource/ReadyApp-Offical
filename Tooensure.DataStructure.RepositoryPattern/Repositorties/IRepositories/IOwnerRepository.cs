using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories
{
    public interface IOwnerRepository : IRepository<Owner>
    {
        ServiceResponse<Owner> Create(string userId);
    }
}
