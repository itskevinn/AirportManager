using System.ComponentModel.DataAnnotations;
using AirportGateway.App.AirportManagement.Http.Dto;
using AirportGateway.App.AirportManagement.Http.Request;
using AirportGateway.App.AirportManagement.Service;
using AirportGateway.App.Base;
using AirportGateway.App.Security;
using Microsoft.AspNetCore.Mvc;

namespace AirportGateway.Api.Controllers;

[ApiController]
[Authorize(new[] { "Admin" })]
[Route("api/[controller]")]
public class CityController : Controller
{
    private readonly ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService ?? throw new ArgumentNullException(nameof(cityService), "City service is null");
    }

    [HttpPost("Create")]
    public async Task<Response<CityDto>> Save([FromBody] CityRequest cityRequest)
    {
        return await _cityService.CreateAsync(cityRequest, HttpContext.Request.Headers.Authorization!);
    }

    [HttpGet("GetAll")]
    public async Task<Response<IEnumerable<CityDto>>> GetAll()
    {
        return await _cityService.GetAllAsync(HttpContext.Request.Headers.Authorization!);
    }

    [HttpGet("GetById/{id:guid}")]
    public async Task<Response<CityDto>> GetById([Required] Guid id)
    {
        return await _cityService.GetByIdAsync(id, HttpContext.Request.Headers.Authorization!);
    }

    [HttpPut("Update")]
    public async Task<Response<CityDto>> Update([FromBody] CityUpdateRequest cityUpdateRequest)
    {
        return await _cityService.UpdateAsync(cityUpdateRequest, HttpContext.Request.Headers.Authorization!);
    }

    [HttpDelete("Delete/{id:guid}")]
    public async Task<Response<bool>> Delete([Required] Guid id)
    {
        return await _cityService.Delete(id, HttpContext.Request.Headers.Authorization!);
    }
}