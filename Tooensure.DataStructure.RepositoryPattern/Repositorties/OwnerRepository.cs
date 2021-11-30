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
    public class OwnerRepository : Repository<Owner>, IOwnerRepository
    {
        public OwnerRepository(DbContext context) : base(context)
        {
        }
        public DataContext? DataContext { get => _context as DataContext; }

        public Task<Owner?> GetOwner(Guid ownerId)
        {
            throw new NotImplementedException();
        }

        public Task<Guid?> GetOwnerIdByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Owner>> GetOwners(Guid BusinessId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isOwner(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isOwner(Guid userId, Guid businessId)
        {
            throw new NotImplementedException();
        }
    }
}
