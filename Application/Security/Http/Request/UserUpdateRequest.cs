namespace Application.Security.Http.Request;

public class UserUpdateRequest : UserRequest
{
    public Guid Id { get; set; }
    public string UpdatedBy { get; set; } = default!;
}