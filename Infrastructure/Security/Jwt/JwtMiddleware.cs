using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repository;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Security.Jwt;
/// <summary>
/// Middleware for handling request for controllers with Authorize notation
/// </summary>
/// <typeparam name="T"></typeparam>
public class JwtMiddleware<T>
{
	private readonly RequestDelegate _next;
	private readonly AppSettings _appSettings;
	private readonly IMapper _mapper;

	public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings, IMapper mapper)
	{
		_next = next;
		_mapper = mapper;
		_appSettings = appSettings.Value;
	}

	public async Task Invoke(HttpContext context, IGenericRepository<User> userRepository,
		IGenericRepository<UserRole> userRoleRepository)
	{
		var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

		if (token != null)
			AttachUserToContext(context, userRepository, token, userRoleRepository);

		await _next(context);
	}

	private void AttachUserToContext(HttpContext context, IGenericRepository<User> userRepository, string token,
		IGenericRepository<UserRole> userRoleRepository)
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
			var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type.ToLower() == "id").Value);
			var user = GetUserInfo(userRepository, userRoleRepository, userId);
			var userDto = _mapper.Map<T>(user);
			context.Items["User"] = userDto;
		}
		catch (Exception e)
		{
			throw new AppException(e.Message);
		}
	}

	private static User GetUserInfo(IGenericRepository<User> userRepository,
		IGenericRepository<UserRole> userRoleRepository, Guid userId)
	{
		var user = userRepository.Find(u => u.Id == userId, false, "UserRoles");
		var userRoles =
			userRoleRepository.GetAsync(ur => ur.UserId == user.Id, null, false, "Role").Result;
		var roles = new List<Role>();
		userRoles.ToList().ForEach(u => { roles.Add(u.Role); });
		user.Roles = roles;
		return user;
	}
}