using Ecommerce.Domain.Entities;
using Tooensure.DataStructure.RepositoryPattern.Repositorties;
using Tooensure.DataStructure.RepositoryPattern.Services.IService;

namespace Tooensure.DataStructure.RepositoryPattern.Services
{
    public class BusinessService : RepositoryService<Business>, IBusinessService
    {
        private readonly BusinessRepository _businesses;
        private readonly OwnerRepository _owners;
        private readonly EmployeeRepository _employees;
        public BusinessService(BusinessRepository businesses, OwnerRepository owner, EmployeeRepository employee)
        {
            _businesses = businesses;
            _owners = owner;
            _employees = employee;
        }
        public async override Task<IEnumerable<Business?>?> All(Guid? userId = null)
        {
            var owners = await _owners.GetAll();
            // var owersWithId = owners.Where(b => b.Name == "shawn Doe");
            // var ownerBusiness = owersWithId.Select(u => u.BusinessId);
        
            // var businessesFromRepoEmployees = (await( _employees.GetAll())).Where(b => b.UserId == id).Select(u => u.Business);

            var businesses = new List<Business?>();
            foreach (var owner in owners)
            {
                if (owner.UserId == userId)
                    businesses.Add((await _businesses.FindById(owner.BusinessId)));
            }

            return businesses;
        }

        public async override Task<Business?> Create(Business entity)
        {
            return (await _businesses.Add(entity));
        }

        public async override Task<Business?> Get(Guid userId, Guid businessId)
        {
            var businesses = await All(userId);
            var business = businesses.FirstOrDefault(b => b.BusinessId == businessId);

            return business != null ? business : null;
        }

        public override Task<Business?> Get(Guid id1)
        {
            throw new NotImplementedException();
        }

    }
}