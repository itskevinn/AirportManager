using Application.Security;
using Infrastructure.Common.Response;

namespace Api.Controllers;

[ApiController]
[Authorize(new []{"Admin"})]
[Route("api/[controller]")]
public class CityController : Controller
{
    private readonly ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
    }

    [HttpPost("Create")]
    public async Task<Response<CityDto>> Save(CityRequest cityService)
    {
        return await _cityService.SaveAsync(cityService);
    }

    [HttpPost("SaveAll")]
    public async Task<Response<Boolean>> Save(IEnumerable<CityRequest> cityRequests)
    {
        return await _cityService.SaveAllAsync(cityRequests);
    }

    [HttpGet("GetAll")]
    public async Task<Response<IEnumerable<CityDto>>> GetAll()
    {
        return await _cityService.GetAllAsync();
    }

    [HttpGet("GetById/{id:guid}")]
    public async Task<Response<CityDto>> GetById(Guid id)
    {
        return await _cityService.GetByIdAsync(id);
    }

    [HttpPut("Update")]
    public async Task<Response<Boolean>> Update(CityUpdateRequest cityUpdateRequest)
    {
        return await _cityService.UpdateAsync(cityUpdateRequest);
    }
    [HttpDelete("Delete/{id:guid}")]
    public async Task<Response<Boolean>> Delete(Guid id)
    {
        return await _cityService.DeleteAsync(id);
    }
}