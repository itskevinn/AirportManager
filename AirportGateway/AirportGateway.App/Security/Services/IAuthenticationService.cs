using AirportGateway.App.Base;
using AirportGateway.App.Core.Interface;
using AirportGateway.App.Security.Http.Dto;
using AirportGateway.App.Security.Http.Request;

namespace AirportGateway.App.Security.Services;

public interface IAuthenticationService : IScopedService
{
    /// <summary>
    /// Method in which authentication is performed.
    /// </summary>
    /// <param name="authenticateRequest" cref="AuthenticateRequest"> Request model of auth sent by client</param>
    /// <returns><see cref="Response{T}"/><see cref="AuthenticateRequest"/></returns>
    Task<Response<AuthenticateDto>> AuthenticateAsync(AuthenticateRequest authenticateRequest);
}