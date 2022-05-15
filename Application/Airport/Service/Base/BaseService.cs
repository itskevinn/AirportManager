using System.Security.Claims;
using Application.Security.Http.Dto;
using Microsoft.AspNetCore.Http;

namespace Application.Airport.Service.Base;

public class BaseService
{
    protected const string AnErrorHappenedMessage = "Ocurrió un error";
    private readonly IHttpContextAccessor? _contextAccessor;

    public BaseService()
    {
    }

    public BaseService(
        IHttpContextAccessor context)
    {
        _contextAccessor = context;
    }

    protected UserDto GetCurrentUser()
    {
        var value = (UserDto)_contextAccessor?.HttpContext.Items["User"]!;
        return (value ?? null)!;
    }
}