using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories;
using Tooensure.DataStructure.RepositoryPattern.Services.IService;

namespace Tooensure.DataStructure.RepositoryPattern.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IUserService Users { get; }

        IBusinessService Businesses { get; }
        IOwnerRepository Owners { get; }

        int Complete();
    }
}
