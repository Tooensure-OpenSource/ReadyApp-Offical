using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        void Add(TEntity entity);
        Task<TEntity?> FindById(Guid id);
        void Remove(TEntity entity);
    }
}
