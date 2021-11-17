using AutoMapper;
using Ecommerce.Domain.Entities;
using Tooensure.DataStructure.RepositoryPattern;

namespace Ecommerce.Server.Grpc.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserLoginDto, User>()
                .ForMember(
                    dest => dest.EmailAddress,
                    opt => opt.MapFrom(src => src.Email));

            CreateMap<UserRegisterDto, User>()
                .ConstructUsingServiceLocator()
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.FirstName))
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => src.LastName))
                .ForMember(
                    dest => dest.Username,
                    opt => opt.MapFrom(src => src.Username))
                .ForMember(
                    dest => dest.EmailAddress,
                    opt => opt.MapFrom(src => src.Email));

            CreateMap<User, UserRegisterDto>()
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.FirstName))
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => src.LastName))
                .ForMember(
                    dest => dest.Username,
                    opt => opt.MapFrom(src => src.Username))
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => src.EmailAddress));


            CreateMap<ServiceResponse<string>, UserDtoModel>()
                .ForMember(
                    dest => dest.Data,
                    opt => opt.MapFrom(src => src.Data))
                .ForMember(
                    dest => dest.IsSuccessful,
                    opt => opt.MapFrom(src => src.Successful))
                .ForMember(
                    dest => dest.Message,
                    opt => opt.MapFrom(src => src.Message));



            CreateMap<ServiceResponse<string>, BusinessDtoModel>();

        }

    }
}
