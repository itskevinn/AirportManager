using Application.Security.Http.Dto;
using Application.Security.Http.Request;
using Application.Security.Service;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public UserController(IUserService userService, IAuthService authService)
    {
        _authService = authService;
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("Authenticate")]
    public async Task<Response<AuthenticateDto>> Authenticate(AuthenticateRequest authenticateRequest)
    {
        return await _authService.Authenticate(authenticateRequest);
    }
    [Infrastructure.Security.Authorize]
    [HttpGet("FindAll")]
    public async Task<Response<IEnumerable<UserDto>>> GetAll()
    {
        return await _userService.GetAll();
    }

    [Infrastructure.Security.Authorize]
    [HttpGet("FindById/{id:guid}")]
    public async Task<Response<UserDto>> GetById(Guid id)
    {
        return await _userService.GetById(id);
    }

    [Infrastructure.Security.Authorize]
    [HttpPost("Save")]
    public async Task<Response<UserDto>> Save(UserRequest userRequest)
    {
        return await _userService.Save(userRequest);
    }
}