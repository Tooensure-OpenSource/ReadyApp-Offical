using AutoMapper;
using Ecommerce.Data;
using Ecommerce.Domain.Entities;
using Ecommerce.Server.Grpc;
using Grpc.Core;
using Tooensure.DataStructure.RepositoryPattern;
using Tooensure.Validation.Formatter;

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
        

        public override Task<UserDtoModel>? UserRegister(UserRegisterDto input, ServerCallContext context)
        {
            // Step 1: Validate requirments
            var reqirments = new ValidationFormatter()
                .AddValidation("First name requied", string.IsNullOrWhiteSpace(input.FirstName))
                .AddValidation("Last name requied", string.IsNullOrWhiteSpace(input.LastName))
                .AddValidation("Username requied", string.IsNullOrWhiteSpace(input.Username))
                .AddValidation("Email requied", string.IsNullOrWhiteSpace(input.Email))
                .AddValidation("Password requied", string.IsNullOrWhiteSpace(input.Password))
                .AddValidation("Token required", string.IsNullOrWhiteSpace(input.Token));


            if (!reqirments.Validate()) return 
                    Task.FromResult(new UserDtoModel() { Data = String.Empty, IsSuccessful=false, Message=$"{reqirments.GetFaildValidation()}"});

            // Step 2: Retrieve user
            var request = _unitOfWork.Users.GetByUserEmail(input.Email);

            if (request.Successful) return
                    Task.FromResult(new UserDtoModel() { Data = String.Empty, IsSuccessful = false, Message = request.Message });


            User user = new(input.Email, input.Password) { FirstName = input.FirstName, LastName = input.LastName, Username = input.Username, Token = input.Token };


            var responseFromRepo = _unitOfWork.Users.Add(user);

            var response = _mapper.Map<UserDtoModel>(responseFromRepo);

            return Task.FromResult(response);

        }


        public override Task<UserDtoModel> UserLogin(UserLoginDto input, ServerCallContext context)
        {
            var reqirments = new ValidationFormatter()
                .AddValidation("Email name requied", string.IsNullOrWhiteSpace(input.Email))
                .AddValidation("Password requied", string.IsNullOrWhiteSpace(input.Password));

            if (!reqirments.Validate()) return
                    Task.FromResult(new UserDtoModel() { Data = String.Empty, IsSuccessful = false, Message = reqirments.GetFaildValidation() });


            var user = _unitOfWork.Users.GetByUser(input.Email, input.Password);

            var response = _mapper.Map<UserDtoModel>(user);

            return Task.FromResult(response);
        }

        private UserDtoModel RegisterUserProccess(UserRegisterDto input)
        {

            /// <summary>
            /// More studies are needed for password hashing and retrieving hash key so that password is stored in its more
            /// secure form
            /// https://stackoverflow.com/questions/3391242/should-i-hash-the-password-before-sending-it-to-the-server-side
            /// var user = _mapper.Map<User>(input, options => options.ConstructServicesUsing(p => new User(input.Password)));
            /// </summary>
            /// var user = _mapper.Map<User>(input);
            //PasswordHahing.CreatePasswordHash(input.Password, out byte[] passwordHash, out byte[] passwordSalt);
            //user.PasswordHash = passwordHash;
            //user.PasswordSalt = passwordSalt;

            var user = _mapper.Map<User>(input, options => options.ConstructServicesUsing(p => new User()));

            var userData = _unitOfWork.Users.Add(user);
            
            
            var response = _mapper.Map<UserDtoModel>(userData);

            return response;
        }


    }
}