using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadyApp.Api.Rest.Models;
using Tooensure.DataStructure.RepositoryPattern;

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
        public async Task<ActionResult<UserDto>> GetUser(LoginDto loginDto)
        {
            var response = await _unitOfWork.Users.UserIdByAuth(loginDto.EmailAddress, loginDto.Password);
            if (response == null) return BadRequest();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddUser(UserCreationDto userCreationDto)
        {
            // Users with existing email should not proceed
            if (await _unitOfWork.Users.ExistByEmail(userCreationDto.EmailAddress)) return BadRequest("User with email exist");
            // Users with existing username should not proceed
            if (await _unitOfWork.Users.ExistByUsername(userCreationDto.Username)) return BadRequest("User with username exist");

            User userInstance = new(userCreationDto.EmailAddress,userCreationDto.Password);
            var user = _mapper.Map<User>(userCreationDto);

            user.PasswordHash = userInstance.PasswordHash;
            user.PasswordSalt = userInstance.PasswordSalt;

            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();

            //var response = await _unitOfWork.Users.FindById(user.Id);

            //if (response == null) return BadRequest();
            return Ok();
        }

    }
}
