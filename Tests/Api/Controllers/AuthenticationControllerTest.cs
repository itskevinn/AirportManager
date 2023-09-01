using Application.Security.Http.Profiles;
using AutoMapper;

namespace Tests.Api.Controllers;

public class AuthenticationControllerTest
{
    private readonly MapperConfiguration _mapperConfig = new(cfg => { cfg.AddProfile(new UserProfile()); });

    private readonly IMapper _userMapper;

    public AuthenticationControllerTest()
    {
        _userMapper = _mapperConfig.CreateMapper();
    }

}