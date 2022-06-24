using Application.Security.Http.Dto;
using Microsoft.AspNetCore.Http;

namespace Application.Airport.Service.Base;

public class BaseService
{
    protected const string AnErrorHappenedMessage = "Ocurrió un error";
    private readonly IHttpContextAccessor? _contextAccessor;

    protected BaseService()
    {
    }

    protected BaseService(
        IHttpContextAccessor context)
    {
        _contextAccessor = context;
    }

    protected UserDto GetCurrentUser()
    {
        var value = (UserDto)_contextAccessor?.HttpContext?.Items["User"]!;
        return value;
    }
}