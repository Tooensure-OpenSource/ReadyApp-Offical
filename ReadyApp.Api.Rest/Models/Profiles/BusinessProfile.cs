using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models.Business;

namespace ReadyApp.Api.Rest.Models.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Business, businessDto>()
                .ForMember(
                    dest => dest.businessId,
                    opt => opt.MapFrom(src => src.BusinessId))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(
                    dest => dest.Usernames,
                    opt => opt.MapFrom(src => src.Username));
        }
    }
}