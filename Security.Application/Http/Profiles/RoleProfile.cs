using AutoMapper;
using Security.Application.Http.Dto;
using Security.Domain.Entity;

namespace Security.Application.Http.Profiles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<Role, RoleDto>().ReverseMap()
            .ForMember(r => r.Authorities, a
                => a.MapFrom(ar => ar.Authorities));
        CreateMap<RoleDto, Security.Infrastructure.Security.Models.RoleDto>().ReverseMap()
            .ForMember(r => r.Authorities, a
                => a.MapFrom(ar => ar.Authorities));
    }
}