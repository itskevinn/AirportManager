using Application.Common.Response;
using Application.Security.Http.Dto;
using Application.Security.Http.Request;

namespace Infrastructure.Security.Authentication.Service;

public interface IAuthService
{
    Task<Response<AuthenticateDto>> Authenticate(AuthenticateRequest authenticateRequest);
    UserDto GetOnlyUserById(Guid id);
}