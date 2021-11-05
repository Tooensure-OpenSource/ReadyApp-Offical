using Ecommerce.Data.Repositories.IRepositories.IUserRepositories;
using Ecommerce.Server.Grpc;
using Grpc.Core;

namespace Ecommerce.Server.Grpc.Services
{
    public class UserAuthService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly IUserAuthRepository _userAuth;

        public UserAuthService(ILogger<GreeterService> logger, IUserAuthRepository userAuth)
        {
            _logger = logger;
            _userAuth = userAuth;
        }

        public override Task<UserDtoModel> UserLogin(UserLoginDto request, ServerCallContext context)
        {
            return Task.FromResult(new UserDtoModel
            {
                Data = String.Empty,
                IsSuccessful = true,
                Message = string.Empty  
            });
        }
    }
}