using AutoMapper;
using Ecommerce.Data;
using Ecommerce.Domain.Entities;
using Ecommerce.Server.Grpc;
using Grpc.Core;
using Tooensure.DataStructure.RepositoryPattern;

namespace Ecommerce.Server.Grpc.Services
{
    public class UserAuthService : UserAuth.UserAuthBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserAuthService(ILogger<GreeterService> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        

        public override Task<UserDtoModel> UserRegister(UserRegisterDto input, ServerCallContext context)
        {

            var user = _mapper.Map<User>(input);

            //var request = _unitOfWork.Users.Security.RegisterAsUser(user, input.Password);
            var request = user.Validate() ? _unitOfWork.Users.Security.RegisterAsUser(user, input.Password) : new ServiceResponse<string>(successful:false);

            var response = new UserDtoModel
            {
                Data = request.Data?.ToString(),
                IsSuccessful = request.Successful,
                Message = request.Successful ? "Success" : "Denied"
            };


            return Task.FromResult(response);
        }


        public override Task<UserDtoModel> UserLogin(UserLoginDto input, ServerCallContext context)
        {
            var response = _unitOfWork.Users.Security.LoginAsUser(input.Email, input.Password);

            // Will install auto mapper in future
            var serviceResponseToUserDtoModel = new UserDtoModel()
            {
                Data = response.Data,
                IsSuccessful = response.Successful,
                Message = response.Message
            };

            return Task.FromResult(serviceResponseToUserDtoModel);
        }
    }
}