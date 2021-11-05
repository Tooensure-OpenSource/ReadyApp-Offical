using Ecommerce.Server.Grpc;
using Grpc.Core;

namespace Ecommerce.Server.Grpc.Services
{
    public class UserAuthService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public UserAuthService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<UserDtoModel> UserLogin(UserLoginDto request, ServerCallContext context)
        {
            return Task.FromResult(new UserDtoModel
            {
                Message = "Hello " + request
            });
        }
    }
}