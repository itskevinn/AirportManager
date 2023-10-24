using AirportGateway.App.Security.Http.Dto;
using AirportGateway.App.Security.Http.Request;
using AutoMapper;

namespace AirportGateway.App.Security.Http.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserRequest, AuthenticateDto>().ReverseMap();
    }
}