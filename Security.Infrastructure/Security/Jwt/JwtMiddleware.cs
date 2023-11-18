using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Security.Domain.Entity;
using Security.Domain.Exceptions;
using Security.Domain.Ports;
using Security.Infrastructure.Utils;

namespace Security.Infrastructure.Security.Jwt;

/// <summary>
/// Middleware for handling request for controllers with Authorize notation
/// </summary>
/// <typeparam name="T">Type of the user dto</typeparam>
public class JwtMiddleware<T>
{
    private readonly RequestDelegate _next;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;

    public JwtMiddleware(RequestDelegate next, IMapper mapper,
        IUserRepository userRepository, IUserRoleRepository userRoleRepository)
    {
        _next = next;
        _mapper = mapper;
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
            await AttachUserToContext(context, _userRepository, token, _userRoleRepository);

        await _next(context);
    }

    private async Task AttachUserToContext(HttpContext context, IGenericRepository<User> userRepository, string token,
        IGenericRepository<UserRole> userRoleRepository)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretsService.GetValue("secret"));
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
            var user = await GetUserInfo(userRepository, userRoleRepository, userId);
            var userDto = _mapper.Map<T>(user);
            context.Items["User"] = userDto;
        }
        catch (Exception e)
        {
            throw new AppException(e.Message);
        }
    }

    private static async Task<User> GetUserInfo(IGenericRepository<User> userRepository,
        IGenericRepository<UserRole> userRoleRepository, Guid userId)
    {
        var user = await userRepository.FindByAsync(u => u.Id == userId, false, "UserRoles");
        var userRoles =
            await userRoleRepository.GetAsync(ur => user != null && ur.UserId == user.Id, null, false, "Role");
        if (user == null) return null!;
        user.Roles = userRoles.Select(u => u.Role);
        return user;
    }
}