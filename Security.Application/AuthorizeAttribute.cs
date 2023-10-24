using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Security.Application.Exceptions;
using Security.Application.Http.Dto;

namespace Security.Application;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly string[] _validRoles;


    public AuthorizeAttribute(string[] validRoles)
    {
        _validRoles = validRoles;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = (UserDto?)context.HttpContext.Items["User"];
        if (user == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (_validRoles is null) throw new MethodWithNotRolesAdmittedException();
        var isAuthorized = false;
        foreach (var rol in _validRoles)
        {
            if (isAuthorized) break;
            isAuthorized = user.Roles.FirstOrDefault(ur => ur.RoleName == rol) != null;
        }

        if (!isAuthorized)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}