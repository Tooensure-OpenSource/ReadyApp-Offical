using Ecommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooensure.DataStructure.RepositoryPattern.Repositorties;
using Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories;
using Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories.ISharedRepositories;
using Tooensure.DataStructure.RepositoryPattern.Repositorties.SharedRepositories;

namespace Tooensure.DataStructure.RepositoryPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Users = new UserRepository(_context);

        }


        public IUserRepository Users { get; private set; }

        public int Complete()
        {
            return _context != null ? _context.SaveChanges() : 0;
        }

        public void Dispose()
        {
            
           if (_context != null) _context.Dispose();
           GC.SuppressFinalize(this);
        }
    }
}
