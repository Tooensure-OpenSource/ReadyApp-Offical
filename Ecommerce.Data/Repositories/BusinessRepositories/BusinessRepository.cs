using Ecommerce.Data.Repositories.IRepositories.IBusinessRepositories;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories.BusinessRepositories
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly DataContext _dataContext;

        public BusinessRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool ExistByUsername(string username)
        {
            return _dataContext.Businesses.Any(b => b.Username == username);
        }

        public ServiceResponse<Guid> Register(Business business, Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}
