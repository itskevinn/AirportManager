using AirportGateway.App.Base;
using AirportGateway.App.Security;
using AirportGateway.App.Security.Http.Dto;
using AirportGateway.App.Security.Http.Request;
using AirportGateway.App.Security.Services;

namespace AirportGateway.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [Authorize(new[] { "Admin" })]
    [HttpGet("FindAll")]
    public async Task<Response<IEnumerable<UserDto>>> GetAll()
    {
        return await _userService.GetAll(HttpContext.Request.Headers["Authorization"]!);
    }

    [Authorize(new[] { "Admin" })]
    [HttpGet("FindById/{id:guid}")]
    public async Task<Response<UserDto>> GetById([FromBody] Guid id)
    {
        return await _userService.GetById(id, HttpContext.Request.Headers["Authorization"]!);
    }

    [Authorize(new[] { "Admin" })]
    [HttpPost("Create")]
    public async Task<Response<UserDto>> Save([FromBody] UserRequest userRequest)
    {
        return await _userService.Save(userRequest, HttpContext.Request.Headers["Authorization"]!);
    }
}