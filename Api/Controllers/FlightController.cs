using Application.Base;
using Application.Http.Dto;
using Application.Http.Request;
using Application.Service;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class FlightController : Controller
{
    private readonly IFlightService _flightService;

    public FlightController(IFlightService flightService)
    {
        _flightService = flightService ?? throw new ArgumentNullException(nameof(flightService));
    }

    [Application.Security.Authorize(new[] { "Admin" })]
    [HttpPost("Create")]
    public async Task<Response<FlightDto>> Save(FlightRequest flightRequest)
    {
        return await _flightService.SaveAsync(flightRequest);
    }
    [AllowAnonymous]
    [HttpGet("GetAll")]
    public async Task<Response<IEnumerable<FlightDto>>> GetAll()
    {
        return await _flightService.GetAllAsync();
    }

    [AllowAnonymous]
    [HttpGet("GetById/{id:guid}")]
    public async Task<Response<FlightDto>> GetById(Guid id)
    {
        return await _flightService.GetByIdAsync(id);
    }

    [Application.Security.Authorize(new[] { "Admin" })]
    [HttpPut("Update")]
    public async Task<Response<bool>> Update(FlightUpdateRequest flightUpdateRequest)
    {
        return await _flightService.UpdateAsync(flightUpdateRequest);
    }

    [Application.Security.Authorize(new[] { "Admin" })]
    [HttpDelete("Delete/{id:guid}")]
    public async Task<Response<bool>> Delete(Guid id)
    {
        return await _flightService.DeleteAsync(id);
    }
}