using AutoMapper;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Server.Grpc.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterDto, User>();
        }
    }
}
