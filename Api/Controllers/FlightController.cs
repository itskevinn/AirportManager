namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlightController : Controller
{
    private readonly IFlightService _flightService;

    public FlightController(IFlightService flightService)
    {
        _flightService = flightService ?? throw new ArgumentNullException(nameof(flightService));
    }

    [HttpPost("Create")]
    public async Task<Response<FlightDto>> Save(FlightRequest flightRequest)
    {
        return await _flightService.SaveAsync(flightRequest);
    }

    [HttpGet("FindAll")]
    public async Task<Response<IEnumerable<FlightDto>>> GetAll()
    {
        return await _flightService.GetAllAsync();
    }

    [HttpGet("FindById/{id:guid}")]
    public async Task<Response<FlightDto>> GetById(Guid id)
    {
        return await _flightService.GetByIdAsync(id);
    }

    [HttpPut("Update")]
    public async Task<Response<Boolean>> Update(FlightUpdateRequest flightUpdateRequest)
    {
        return await _flightService.UpdateAsync(flightUpdateRequest);
    }

    [HttpDelete("Remove/{id:guid}")]
    public async Task<Response<Boolean>> Delete(Guid id)
    {
        return await _flightService.DeleteAsync(id);
    }
}