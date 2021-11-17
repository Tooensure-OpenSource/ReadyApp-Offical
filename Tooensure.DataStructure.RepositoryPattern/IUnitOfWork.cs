using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories;

namespace Tooensure.DataStructure.RepositoryPattern
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IBusinessRepository Businesses { get; }
        IOwnerRepository Owners { get; }

        int Complete();
    }
}
