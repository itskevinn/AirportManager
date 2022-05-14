using Application.Common.Response;
using Application.Security.Http.Dto;
using Application.Security.Http.Request;
using Infrastructure.Common.Interface;

namespace Infrastructure.Security.Authentication.Service;

public interface IAuthService : IScopedService
{
    Task<Response<AuthenticateDto>> Authenticate(AuthenticateRequest authenticateRequest);
    UserDto GetOnlyUserById(Guid id);
}