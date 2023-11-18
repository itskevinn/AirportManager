using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AirportGateway.App.Base;
using Microsoft.IdentityModel.Tokens;

namespace AirportGateway.App.Security.Jwt;

public class JwtUtils<T> : IJwtUtils<T> where T : class
{
    public string GenerateJwtToken(T userDto)
    {
        var propertyInfo = userDto.GetType().GetProperty("Id");
        if (propertyInfo == null) return "Property 'Id' not found.";

        var id = Guid.Parse(propertyInfo.GetValue(userDto)?.ToString() ?? string.Empty);
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(ConfigMapService.GetConfiguration()["secret"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", id.ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public Guid ValidateJwtToken(string? token)
    {
        if (token == null)
            return Guid.Empty;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(ConfigMapService.GetConfiguration()["secret"]);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            return userId;
        }
        catch
        {
            return Guid.Empty;
        }
    }
}