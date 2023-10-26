using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AirportGateway.App.Core.Helpers;
using AirportGateway.App.Exceptions;
using AirportGateway.App.Security.Http.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace AirportGateway.App.Security.Jwt;

/// <summary>
/// Middleware for handling request for controllers with Authorize notation
/// </summary>
public class SecurityMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public SecurityMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
            AttachUserToContext(context, token);

        await _next(context);
    }

    private void AttachUserToContext(HttpContext context, string token)
    {
        try
        {
            var jwtToken = ValidateToken(token);
            var userDto = BuildUserInfo(jwtToken);
            context.Items["User"] = userDto;
        }
        catch (Exception e)
        {
            throw new AppException(e.Message);
        }
    }

    private static UserDto BuildUserInfo(JwtSecurityToken jwtToken)
    {
        Guid.TryParse(jwtToken.Claims.First(x => x.Type.ToLower() == "id").Value, out var userId);
        var username = jwtToken.Claims.First(x => x.Type.ToLower() == "username").Value;
        var roles = GetUserRoles(jwtToken.Payload.First(x => x.Key == "Roles"));
        if (userId == Guid.Empty) throw new InvalidOperationException("id must be in the claims");
        if (username == string.Empty) throw new InvalidOperationException("username must be in the claims");
        var userDto = new UserDto
        {
            Id = userId,
            Username = username,
            Roles = roles
        };
        return userDto;
    }

    private JwtSecurityToken ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        }, out var validatedToken);

        var jwtToken = (JwtSecurityToken)validatedToken;
        return jwtToken;
    }

    private static IEnumerable<RoleDto>? GetUserRoles(KeyValuePair<string, object> claims)
    {
        var rolesJson = claims.Value.ToString()!;
        var roles = JsonConvert.DeserializeObject<IEnumerable<RoleDto>>(rolesJson);
        return roles;
    }
}