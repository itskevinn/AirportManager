namespace Application.Security.Http.Dto;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string RoleName { get; set; } = default!;
    public string Username { get; set; } = default!;
    public IEnumerable<RoleDto> Roles { get; set; } = default!;
}