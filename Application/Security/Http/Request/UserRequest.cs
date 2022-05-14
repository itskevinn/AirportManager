using Domain.Constants.Enum;

namespace Application.Security.Http.Request;

public class UserRequest
{
    public string Name { get; set; }
    public RoleNameEnum RoleName { get; set; }
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
}