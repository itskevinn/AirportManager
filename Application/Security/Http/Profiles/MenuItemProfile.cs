using Application.Security.Http.Dto;

namespace Application.Security.Http.Profiles;

public class MenuItemProfile : Profile
{
    public MenuItemProfile()
    {
        CreateMap<MenuItem, MenuItemDto>().ReverseMap();
    }
}