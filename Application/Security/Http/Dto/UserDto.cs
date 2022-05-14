using Domain.Constants.Enum;

namespace Application.Security.Http.Dto;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public RoleNameEnum RoleName { get; set; }
    public string Username { get; set; } = default!;
}