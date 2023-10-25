namespace Security.Application.Http.Request;

public class UserRequest
{
    public string Name { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public IEnumerable<Guid> RolesId { get; set; } = Enumerable.Empty<Guid>();
}