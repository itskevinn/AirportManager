using AirportGateway.App.Base;
using AirportGateway.App.Security.Http.Dto;
using AirportGateway.App.Security.Http.Request;
using AirportGateway.App.Security.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketsGateway.Application.Base;
using TicketsGateway.Application.Security.Http.Dto;
using TicketsGateway.Application.Security.Http.Request;
using TicketsGateway.Application.Security.Services;

namespace TicketsGateway.Api.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
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