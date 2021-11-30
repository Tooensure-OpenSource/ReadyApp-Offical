using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tooensure.DataStructure.RepositoryPattern.Repositorties.IRepositories
{
    public interface IOwnerRepository : IRepository<Owner>
    {
        /// <summary>
        /// Check if a user is registerd as a owner of some sort of business
        /// </summary>
        /// <param name="userId">User GUID is a great way to sidentify user</param>
        /// <returns>true if data store has user id in owners table</returns>
        Task<bool> isOwner(Guid userId);
        /// <summary>
        /// A owner may be a owner, check if user is a owner of a specific business
        /// </summary>
        /// <param name="userId">user GUID </param>
        /// <param name="businessId">business Guid in relation to the user who is the owner</param>
        /// <returns>true if user is the owner of the business else false</returns>
        Task<bool> isOwner(Guid userId, Guid businessId);

        /// <summary>
        /// Finding the owner by user Id will provide the information of retrieving the owner Id
        /// </summary>
        /// <param name="userId">The user Guid</param>
        /// <returns>Owner Guid else null</returns>
        Task<Guid?> GetOwnerIdByUserId(Guid userId);
        /// <summary>
        /// After finding the owner Guid may be nice to retrieve the owner object
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        Task<Owner?> GetOwner(Guid ownerId);
        
        /// <summary>
        /// Retrieve all owners of a specific business
        /// </summary>
        /// <param name="BusinessId"></param>
        /// <returns>A list of businesses</returns>
        Task<IEnumerable<Owner>> GetOwners(Guid BusinessId);
        

    }
}
