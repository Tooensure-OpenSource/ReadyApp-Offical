using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        ServiceResponse2v<string> Add(TEntity entity);
        TEntity? FindById(Guid id);
        void Remove(TEntity entity);
    }
}
