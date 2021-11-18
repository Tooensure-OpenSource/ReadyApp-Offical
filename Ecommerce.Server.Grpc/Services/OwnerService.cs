using AutoMapper;
using Grpc.Core;
using Tooensure.DataStructure.RepositoryPattern;
using Tooensure.Validation.Formatter;

namespace Ecommerce.Server.Grpc.Services
{
    public class OwnerService : OwnerDto.OwnerDtoBase
    {
        private readonly ILogger<OwnerService> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OwnerService(ILogger<OwnerService> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public override Task<OwnerDtoModel> GetOwnersFromBusiness(BusinessIdDto input, ServerCallContext context)
        {

            var reqirments = new ValidationFormatter()
                .AddValidation("Business needs owner requied", string.IsNullOrWhiteSpace(input.BusinessId)); ;

            if (!reqirments.Validate()) return
                    Task.FromResult(new OwnerDtoModel() { Data = String.Empty, Successful = false, Message = reqirments.GetFaildValidation() });


            return Task.FromResult(new OwnerDtoModel());

        }


    }
}