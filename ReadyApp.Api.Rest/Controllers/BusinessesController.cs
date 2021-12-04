using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models.Business;
using Microsoft.AspNetCore.Mvc;
using Tooensure.DataStructure.RepositoryPattern.UOW;

namespace ReadyApp.Api.Rest.Controllers
{

    [Route("api/users/{userId}/businesses")]
    [ApiController]
    public class BusinessesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BusinessesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<businessDto?>?>> All(Guid userId)
        {          
            if (userId == null) BadRequest();
            var businessesFromRepo = await _unitOfWork.Businesses.All(userId);
            var response = new List<businessDto>();

            if( businessesFromRepo != null)
            {
                foreach (var business in businessesFromRepo)
                {
                    response.Add(_mapper.Map<businessDto>(business));
                }
            }
            return response;
        }

        [HttpGet("{businessId}")]
        public async Task<ActionResult<businessDto?>> Get(Guid userId, Guid BusinessId)
        {
            var response = await _unitOfWork.Businesses.Get(userId, BusinessId);
            return _mapper.Map<businessDto>(response);
        }

        [HttpPost]
        public async Task<ActionResult<businessDto?>> Create(Guid userId, AddBusinessDto businessDto)
        {
            var user = await _unitOfWork.Users.Get(userId);
            Business business = new(user, businessDto.Name, businessDto.Username);
            var response = await _unitOfWork.Businesses.Create(business);
            _unitOfWork.Complete();
            return _mapper.Map<businessDto>(response);
        }
    }
}