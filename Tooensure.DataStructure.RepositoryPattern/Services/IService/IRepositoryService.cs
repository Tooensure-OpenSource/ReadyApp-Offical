using Ecommerce.Domain.Entities;

namespace Tooensure.DataStructure.RepositoryPattern.Services.IService
{
    public interface IRepositoryService<T> where T : class
    {
        // Get objects
        Task<IEnumerable<T?>?> All(Guid? id = null);
        // Get object
        Task<T?> Get(Guid id1);
        Task<T?> Get(Guid id1, Guid id2);

        // Post
        Task<T?> Create(T obj);
    }
}