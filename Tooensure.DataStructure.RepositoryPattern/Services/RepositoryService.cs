using Tooensure.DataStructure.RepositoryPattern.Services.IService;

namespace Tooensure.DataStructure.RepositoryPattern.Services
{
    public abstract class RepositoryService<T> : IRepositoryService<T> where T : class
    {

        public abstract Task<IEnumerable<T?>?> All(Guid? id = null);
        public abstract Task<T?> Get(Guid id1);
        public abstract Task<T?> Get(Guid id1, Guid id2);

        public abstract Task<T?> Create(T user);

    }
}