using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models;

namespace ReadyApp.Api.Rest.Models.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // User Creation Dto made from the client needs to map to user entity for operation
            // Password is inserted  into the token and will be hashed on the server
            // Hasing and password into token will be enhanced in higher version releases
            CreateMap<UserCreationDto, User>()
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
                    dest => dest.Token,
                    opt => opt.MapFrom(src => src.Password))
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.EmailAddress));

            // After operations the server will reply with a request and if seuccessful the user will need to map to a tranfer object
            CreateMap<User, UserDto>()
                .ForMember(
                    dest => dest.UserId,
                    opt => opt.MapFrom(src => src.Id))
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
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.EmailAddress));
        }

    }
}
