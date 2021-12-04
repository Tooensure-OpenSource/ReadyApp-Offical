using Ecommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooensure.DataStructure.RepositoryPattern.Repositorties;
using Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories;
using Tooensure.DataStructure.RepositoryPattern.Services;
using Tooensure.DataStructure.RepositoryPattern.Services.IService;

namespace Tooensure.DataStructure.RepositoryPattern.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Users = new UserService(new UserRepository(_context));
            Businesses = 
            new BusinessService(
                new BusinessRepository(_context), 
                new OwnerRepository(_context), 
                new EmployeeRepository(_context));
            Owners = new OwnerRepository(_context);

            // SecurityDir = new SecurityDirectory(_context);

        }

        public IUserService Users { get; private set; }
        // public IUserRepository Users { get; private set; }
        public IBusinessService Businesses { get; private set; }
        public IOwnerRepository Owners { get; private set; }


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
