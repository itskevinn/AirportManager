using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security.Application.Base;
using Security.Application.Http.Dto;
using Security.Application.Http.Request;
using Security.Application.Service;

namespace Security.Api.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("Authenticate")]
    public async Task<Response<AuthenticateDto>> Authenticate(AuthenticateRequest authenticateRequest)
    {
        return await _authService.Authenticate(authenticateRequest);
    }

    [AllowAnonymous]
    [HttpGet("GetUserIdFromToken")]
    public Guid GetUserIdFromToken(string token)
    {
        return _authService.GetUserIdFromToken(token);
    }
}