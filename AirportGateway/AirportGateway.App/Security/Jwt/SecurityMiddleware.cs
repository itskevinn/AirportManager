using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AirportGateway.App.Core.Helpers;
using AirportGateway.App.Exceptions;
using AirportGateway.App.Security.Http.Dto;
using AirportGateway.App.Security.RestEaseClients;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

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
            await AttachUserToContext(context, token);

        await _next(context);
    }

    private async Task AttachUserToContext(HttpContext context, string token)
    {
        try
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
            Guid.TryParse(jwtToken.Claims.First(x => x.Type.ToLower() == "id").Value, out var userId);
            if (userId == Guid.Empty) throw new InvalidOperationException("id must be in the claims");
            var userDto = await GetUserInfo(userId, token);
            context.Items["User"] = userDto;
        }
        catch (Exception e)
        {
            throw new AppException(e.Message);
        }
    }

    private async Task<UserDto> GetUserInfo(Guid userId, string token)
    {
        var userRestEaseClient = RestEase.RestClient.For<IUserRestEaseClient>(_appSettings.MicroservicesUrls.SecurityUrl);
        var user = await userRestEaseClient.GetById(userId, token);
        return user.Data;
    }
}