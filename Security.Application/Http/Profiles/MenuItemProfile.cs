using AutoMapper;
using Security.Application.Http.Dto;
using Security.Domain.Entity;

namespace Security.Application.Http.Profiles;

public class MenuItemProfile : Profile
{
    public MenuItemProfile()
    {
        CreateMap<MenuItem, MenuItemDto>().ReverseMap();
    }
}