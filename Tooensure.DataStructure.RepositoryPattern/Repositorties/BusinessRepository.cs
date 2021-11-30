using Ecommerce.Data;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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


        /// <summary>
        /// Retrieve first business containing username in data store
        /// </summary>
        /// <param name="username">username in connection to business</param>
        /// <returns>A business object with username witch can be null if not found</returns>
        public async Task<Business?> GetBusinessByUsername(string username)
        {

            if (DataContext?.Businesses != null)
                return await DataContext.Businesses.SingleOrDefaultAsync(b => b.Username == username);
            return null;
        }        
    }
}
