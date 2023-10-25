using System.ComponentModel.DataAnnotations;
using AirportGateway.App.AirportManagement.Http.Dto;
using AirportGateway.App.AirportManagement.Http.Request;
using AirportGateway.App.AirportManagement.Service;
using AirportGateway.App.Base;
using Microsoft.AspNetCore.Authorization;

namespace AirportGateway.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlightController : Controller
{
    private readonly IFlightService _flightService;

    public FlightController(IFlightService flightService)
    {
        _flightService = flightService ?? throw new ArgumentNullException(nameof(flightService));
    }

    [App.Security.Authorize(new[] { "Admin" })]
    [HttpPost("Create")]
    public async Task<Response<FlightDto>> Save([FromBody] FlightRequest flightRequest)
    {
        return await _flightService.CreateAsync(flightRequest, HttpContext.Request.Headers.Authorization!);
    }

    [AllowAnonymous]
    [HttpGet("GetAll")]
    public async Task<Response<IEnumerable<FlightDto>>> GetAll()
    {
        return await _flightService.GetAllAsync(HttpContext.Request.Headers.Authorization!);
    }

    [AllowAnonymous]
    [HttpGet("GetById/{id:guid}")]
    public async Task<Response<FlightDto>> GetById([Required] Guid id)
    {
        return await _flightService.GetByIdAsync(id, HttpContext.Request.Headers.Authorization!);
    }

    [App.Security.Authorize(new[] { "Admin" })]
    [HttpPut("Update")]
    public async Task<Response<FlightDto>> Update([FromBody] FlightUpdateRequest flightUpdateRequest)
    {
        return await _flightService.Update(flightUpdateRequest, HttpContext.Request.Headers.Authorization!);
    }
}