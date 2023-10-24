using Application.Base;
using Application.Http.Dto;
using Application.Http.Request;
using Application.Security;
using Application.Service;

namespace Api.Controllers;

[Authorize(new []{"Admin"})]
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
        return await _airlineService.GetAllAsync();
    }

    [HttpGet("GetById/{id:guid}")]
    public async Task<Response<AirlineDto>> GetById(Guid id)
    {
        return await _airlineService.GetByIdAsync(id);
    }

    [HttpPost("Create")]
    public async Task<Response<AirlineDto>> Save(AirlineRequest airlineRequest)
    {
        return await _airlineService.SaveAsync(airlineRequest);
    }

    [HttpPut("Update")]
    public async Task<Response<AirlineDto>> Update(AirlineUpdateRequest airlineRequest)
    {
        return await _airlineService.UpdateAsync(airlineRequest);
    }

    [HttpDelete("Delete/{id:guid}")]
    public async Task<Response<bool>> Update(Guid id)
    {
        return await _airlineService.DeleteAsync(id);
    }
}