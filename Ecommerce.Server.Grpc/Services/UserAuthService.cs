using Ecommerce.Data;
using Ecommerce.Data.Repositories.IRepositories.IUserRepositories;
using Ecommerce.Domain.Entities;
using Ecommerce.Server.Grpc;
using Grpc.Core;

namespace Ecommerce.Server.Grpc.Services
{
    public class UserAuthService : UserAuth.UserAuthBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly IUserAuthRepository _userAuth;

        public UserAuthService(ILogger<GreeterService> logger, IUserAuthRepository userAuth)
        {
            _logger = logger;
            _userAuth = userAuth;
        }

        public override Task<UserDtoModel> UserRegister(UserRegisterDto request, ServerCallContext context)
        {            
            var user = new User()
            {
                Username = request.Username,
                EmailAddress = request.Email
            };

            var userFromRepo = _userAuth.Register(user, request.Password);

            if (!userFromRepo.IsSuccessful)
            {
                return Task.FromResult(new UserDtoModel
                {
                    Data = string.Empty,
                    IsSuccessful = userFromRepo.IsSuccessful,
                    Message = userFromRepo.Message
                });
            }

            return Task.FromResult(new UserDtoModel
            {
                Data = userFromRepo.Data.ToString(),
                IsSuccessful = userFromRepo.IsSuccessful,
                Message = userFromRepo.Message
            });
        }
    }
}