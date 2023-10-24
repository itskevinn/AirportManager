using System.Net;
using AirportGateway.App.Base;
using AirportGateway.App.Core.Helpers;
using AirportGateway.App.Security.Http.Dto;
using AirportGateway.App.Security.Http.Request;
using AirportGateway.App.Security.RestEaseClients;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AirportGateway.App.Security.Services.Implementation;

public class AuthenticationService : BaseService, IAuthenticationService
{
    private readonly IAuthenticationRestEaseClient _authenticationRestClient;
    private readonly ILogger<AuthenticationService> _logger;

    public AuthenticationService(IOptions<AppSettings> appSettings, ILogger<AuthenticationService> logger,
        IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _logger = logger;
        _authenticationRestClient =
            RestEase.RestClient.For<IAuthenticationRestEaseClient>(appSettings.Value.MicroservicesUrls.SecurityUrl);
    }

    public async Task<Response<AuthenticateDto>> AuthenticateAsync(AuthenticateRequest authenticateRequest)
    {
        try
        {
            var authenticatedUserDto = await _authenticationRestClient.AuthenticateAsync(authenticateRequest);
            return authenticatedUserDto;
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "{AnErrorHappenedMessage} {EMessage}", AnErrorHappenedMessage, e.Message);
            return new Response<AuthenticateDto>(HttpStatusCode.InternalServerError,
                AnErrorHappenedMessage,
                false, null!, e);
        }
    }
}