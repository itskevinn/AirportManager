namespace Security.Application.Http.Dto;

public class AuthenticateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }
    public IEnumerable<RoleDto> Roles { get; set; }


    public AuthenticateDto(UserDto user, string token)
    {
        Id = user.Id;
        Name = user.Name;
        Username = user.Username;
        Roles = user.Roles;
        Token = token;
    }
}