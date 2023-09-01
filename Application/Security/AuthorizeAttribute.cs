using Application.Exceptions;
using Application.Security.Http.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Application.Security;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly string[] _validRoles;
    private readonly LoggerFactory _loggerFactory = new();

    public AuthorizeAttribute(string[] validRoles)
    {
        _validRoles = validRoles;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = (UserDto)context.HttpContext.Items["User"]!;

        if (_validRoles is null) throw new MethodWithNotRolesAdmittedException();
        IEnumerable<RoleDto> userRoles = new List<RoleDto>();
        foreach (var role in _validRoles)
        {
            userRoles = user.Roles.Where(r => r.RoleName == role);
        }

        if (!userRoles.Any())
        {
            context.Result = new UnauthorizedResult();
        }
    }
}