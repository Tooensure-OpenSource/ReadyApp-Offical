using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories.IRepositories.IBusinessRepositories
{
    public interface IBusinessRepository
    {
        ServiceResponse<Guid> Register(Business business, Owner owner);
        bool ExistByUsername(string username);
    }
}
