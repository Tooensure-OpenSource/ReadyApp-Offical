using Ecommerce.Data;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories;

namespace Tooensure.DataStructure.RepositoryPattern.Repositorties
{
    public class BusinessRepository : Repository<Business>, IBusinessRepository
    {
        public BusinessRepository(DbContext context) : base(context) { }
        public DataContext? DataContext { get => _context as DataContext; }


        public ServiceResponse<string> GetBusinessByUsername(string username)
        {
            var businessUsername = DataContext?.Businesses?.SingleOrDefault(b => b.Username == username)?.BusinessId.ToString();
            var businessWithUserExist = !string.IsNullOrEmpty(businessUsername);
            return
                new(
                    Data: businessUsername ?? string.Empty,
                    Successful: businessWithUserExist,
                    Message: businessWithUserExist ? " Search verified" : "Business with username don't exist");
        }
        public ServiceResponse<string> Add(User user,Business entity)
        {
            Owner owner = new(user);

            DataContext?.Owners?.Attach(owner);
            DataContext?.Businesses?.Add(entity);
            return base.Add(entity);
        }
    }
}
