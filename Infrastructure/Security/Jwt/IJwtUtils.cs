using Application.Security.Http.Dto;

namespace Infrastructure.Security.Jwt;

public interface IJwtUtils
{
    string GenerateJwtToken(UserDto userDto);
    Guid ValidateJwtToken(string token);
}