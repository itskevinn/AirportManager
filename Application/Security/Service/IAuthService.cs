using Application.Security.Http.Dto;
using Application.Security.Http.Request;
using Infrastructure.Common.Interface;
using Infrastructure.Common.Response;

namespace Application.Security.Service;

public interface IAuthService : IScopedService
{
    Task<Response<AuthenticateDto>> Authenticate(AuthenticateRequest authenticateRequest);
    Task<UserDto> GetOnlyUserById(Guid id);
}