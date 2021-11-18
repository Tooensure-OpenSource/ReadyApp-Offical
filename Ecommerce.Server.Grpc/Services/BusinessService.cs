using AutoMapper;
using Ecommerce.Data;
using Ecommerce.Domain.Entities;
using Ecommerce.Server.Grpc;
using Grpc.Core;
using Tooensure.DataStructure.RepositoryPattern;
using Tooensure.Validation.Formatter;

namespace Ecommerce.Server.Grpc.Services
{
    public class BusinessService : BusinessDto.BusinessDtoBase
    {
        private readonly ILogger<BusinessService> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BusinessService(ILogger<BusinessService> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        

        public override Task<BusinessDtoModel>? BusinessRegister(BusinessRegisterDto input, ServerCallContext context)
        {

            var reqirments = new ValidationFormatter()
                .AddValidation("Busines username requied", string.IsNullOrWhiteSpace(input.Username))
                .AddValidation("Busines name requied", string.IsNullOrWhiteSpace(input.Name))
                .AddValidation("Business needs owner requied", string.IsNullOrWhiteSpace(input.UserId));

            if (!reqirments.Validate()) return
                    Task.FromResult(new BusinessDtoModel() { Data = String.Empty, Successful = false, Message = reqirments.GetFaildValidation() });

            var user = _unitOfWork.Users.FindById(Guid.Parse(input.UserId));

            var business = new Business(user) { Name = input.Name, Username = input.Username };

            var businessInfo = _unitOfWork.Businesses.Add(business);

            var response = _mapper.Map<BusinessDtoModel>(businessInfo);
            
            return Task.FromResult(response);

        }

        public override Task<BusinessDtoModel>? BusinessSearch(BusinessUsernameDto input, ServerCallContext context)
        {

            var reqirments = new ValidationFormatter()
                .AddValidation("Search username requied", string.IsNullOrWhiteSpace(input.Username));

            if (!reqirments.Validate()) return
                    Task.FromResult(new BusinessDtoModel() { Data = String.Empty, Successful = false, Message = reqirments.GetFaildValidation() });

            var request = _unitOfWork.Businesses.GetBusinessByUsername(input.Username);

            var response = _mapper.Map<BusinessDtoModel>(request);

            return Task.FromResult(response);

        }
    }
}