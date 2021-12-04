using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tooensure.DataStructure.RepositoryPattern.UOW;

namespace ReadyApp.Api.Rest.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> All()
        {
            var usersFromRepo = (await _unitOfWork.Users.All())?.ToList();

            var users = new List<UserDto>();

            if(usersFromRepo != null)
            {
                foreach (var user in usersFromRepo)
                {
                    users.Add(_mapper.Map<UserDto>(user));
                }
            }
            return users;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDto>> Get(Guid userId)
        {
            var user = _mapper.Map<UserDto>(await GetFromRepo(userId));
            if (user == null) return BadRequest("Can't proccess");
            return Ok(user);
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> AddUser(AddUserDto userCreationDto)
        {

            User userInstance = new(userCreationDto.EmailAddress,userCreationDto.Password);
            var user = _mapper.Map<User>(userCreationDto);

            user.PasswordHash = userInstance.PasswordHash;
            user.PasswordSalt = userInstance.PasswordSalt;

            var response = await _unitOfWork.Users.Create(user);
            _unitOfWork.Complete();

            if (response == null) return BadRequest();
            return Ok(response?.UserId);
        }

        private async Task<User?> GetFromRepo(Guid userId)
        {
            return await _unitOfWork.Users.Get(userId);
        }

    }
}
