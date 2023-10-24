using AirportGateway.App.AirportManagement.Http.Dto;
using AirportGateway.App.AirportManagement.Http.Request;
using AirportGateway.App.AirportManagement.Service;
using AirportGateway.App.Base;

namespace AirportGateway.Api.Controllers;

[App.Security.Authorize(new[] { "Admin" })]
[ApiController]
[Route("api/v1/[controller]")]
public class AirlineController : Controller
{
    private readonly IAirlineService _airlineService;

    public AirlineController(IAirlineService airlineService)
    {
        _airlineService = airlineService;
    }

    [HttpGet("GetAll")]
    public async Task<Response<IEnumerable<AirlineDto>>> GetAll()
    {
        return await _airlineService.GetAllAsync(HttpContext.Request.Headers.Authorization!);
    }

    [HttpPost("Create")]
    public async Task<Response<AirlineDto>> Save(AirlineRequest airlineRequest, string token)
    {
        return await _airlineService.CreateAsync(airlineRequest, HttpContext.Request.Headers.Authorization!);
    }

    [HttpPut("Update")]
    public async Task<Response<AirlineDto>> Update(AirlineUpdateRequest airlineRequest, string token)
    {
        return await _airlineService.UpdateAsync(airlineRequest, HttpContext.Request.Headers.Authorization!);
    }

    [HttpDelete("Delete/{id:guid}")]
    public async Task<Response<bool>> Delete(Guid id, string token)
    {
        return await _airlineService.Delete(id, HttpContext.Request.Headers.Authorization!);
    }
}