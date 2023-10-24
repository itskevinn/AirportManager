using Security.Application.Base;
using Security.Application.Http.Dto;
using Security.Application.Http.Request;
using Security.Infrastructure.Core.Interface;

namespace Security.Application.Service;

public interface IAuthService : IScopedService
{
    /// <summary>
    /// Method in which authentication is performed.
    /// </summary>
    /// <param name="authenticateRequest" cref="AuthenticateRequest"> Request model of auth sent by client</param>
    /// <returns><see cref="Response{T}"/><see cref="AuthenticateRequest"/></returns>
    Task<Response<AuthenticateDto>> Authenticate(AuthenticateRequest authenticateRequest);

    /// <summary>
    /// Method used to get the user id from the given token
    /// </summary>
    /// <param name="token"></param>
    /// <returns>user id if the token is valid, null if not</returns>
    Guid GetUserIdFromToken(string token);
}