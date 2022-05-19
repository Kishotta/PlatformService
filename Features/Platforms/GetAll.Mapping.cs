using AutoMapper;
using PlatformService.Entities;

namespace PlatformService.Features.Platforms.GetAll;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Platform, Response>(MemberList.None)
            .ForMember(dest => dest.Id, option => option.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, option => option.MapFrom(src => src.Name))
            .ForMember(dest => dest.Publisher, option => option.MapFrom(src => src.Publisher))
            .ForMember(dest => dest.Cost, option => option.MapFrom(src => src.Cost));
    }
}
