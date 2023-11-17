using System.ComponentModel.DataAnnotations;
using AirportGateway.App.AirportManagement.Http.Dto;
using AirportGateway.App.AirportManagement.Http.Request;
using AirportGateway.App.AirportManagement.Service;
using Microsoft.AspNetCore.Mvc;

namespace AirportGateway.Api.Controllers;

[App.Security.Authorize(new[] { "Admin" })]
[ApiController]
[Route("api/[controller]")]
public class AirlineController : Controller
{
    private readonly IAirlineService _airlineService;

    public AirlineController(IAirlineService airlineService)
    {
        _airlineService = airlineService;
    }

    [HttpGet("GetAll")]
    public async Task<App.Base.Response<IEnumerable<AirlineDto>>> GetAll()
    {
        return await _airlineService.GetAllAsync(HttpContext.Request.Headers.Authorization!);
    }

    [HttpPost("Create")]
    public async Task<App.Base.Response<AirlineDto>> Save([FromBody] AirlineRequest airlineRequest)
    {
        return await _airlineService.CreateAsync(airlineRequest, HttpContext.Request.Headers.Authorization!);
    }

    [HttpPut("Update")]
    public async Task<App.Base.Response<AirlineDto>> Update([FromBody] AirlineUpdateRequest airlineRequest)
    {
        return await _airlineService.UpdateAsync(airlineRequest, HttpContext.Request.Headers.Authorization!);
    }

    [HttpDelete("Delete/{id:guid}")]
    public async Task<App.Base.Response<bool>> Delete([Required] Guid id)
    {
        return await _airlineService.Delete(id, HttpContext.Request.Headers.Authorization!);
    }
}