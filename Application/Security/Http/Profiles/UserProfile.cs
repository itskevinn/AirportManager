using Application.Security.Http.Dto;
using Application.Security.Http.Request;
using Domain.Entities;

namespace Application.Security.Http.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserRequest, User>().ReverseMap();
        CreateMap<UserUpdateRequest, User>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}