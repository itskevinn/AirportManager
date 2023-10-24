using AirportGateway.App.Security.Http.Dto;
using Microsoft.AspNetCore.Http;

namespace AirportGateway.App.Base;

public class BaseService : IBaseService
{
    private readonly IHttpContextAccessor? _contextAccessor;

    protected const string AnErrorHappenedMessage = "Ocurrió un error";

    protected BaseService(IHttpContextAccessor context)
    {
        _contextAccessor = context;
    }

    protected BaseService()
    {
    }

    public UserDto GetCurrentUser()
    {
        return (UserDto)_contextAccessor?.HttpContext?.Items["User"]!;
    }
}