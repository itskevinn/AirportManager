using Application.Security.Http.Dto;
using Infrastructure.Common.Interface;

namespace Infrastructure.Security.Jwt;

public interface IJwtUtils : IScopedService
{
    string GenerateJwtToken(UserDto userDto);
    Guid ValidateJwtToken(string token);
}