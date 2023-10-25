using AirportGateway.App.Base;
using AirportGateway.App.Security.Http.Dto;
using AirportGateway.App.Security.Http.Request;
using AirportGateway.App.Security.Services;
using Microsoft.AspNetCore.Authorization;

namespace AirportGateway.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [AllowAnonymous]
    [HttpPost("Authenticate")]
    public async Task<Response<AuthenticateDto>> Authenticate(AuthenticateRequest authenticateRequest)
    {
        return await _authenticationService.AuthenticateAsync(authenticateRequest);
    }
}