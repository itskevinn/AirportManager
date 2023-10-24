namespace Application.Http.Dto;

public class RoleDto
{
    public Guid Id { get; set; }
    public string RoleName { get; set; } = default!;
    public IEnumerable<MenuItemDto> Authorities { get; set; } = default!;
}