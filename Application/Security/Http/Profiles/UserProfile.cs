using Application.Security.Http.Dto;
using Application.Security.Http.Request;

namespace Application.Security.Http.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserRequest, User>().ReverseMap();
        CreateMap<UserUpdateRequest, User>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap()
            .ForMember(r => r.Roles, u
                => u.MapFrom(ur => ur.Roles));
    }
}