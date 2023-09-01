namespace Application.Security.Http.Request;

public class UserRequest
{
    public string Name { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string CreatedBy { get; set; } = default!;
    public Guid RoleId { get; set; } = default!;
}