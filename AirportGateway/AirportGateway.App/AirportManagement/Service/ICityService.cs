using AirportGateway.App.AirportManagement.Http.Dto;
using AirportGateway.App.AirportManagement.Http.Request;
using AirportGateway.App.Base;
using AirportGateway.App.Core.Interface;

namespace AirportGateway.App.AirportManagement.Service;

public interface ICityService : ITransientService
{
    Task<Response<IEnumerable<CityDto>>> GetAllAsync(string token);
    Task<Response<CityDto>> GetByIdAsync(Guid cityId, string token);
    Task<Response<CityDto>> CreateAsync(CityRequest request, string token);
    Task<Response<CityDto>> UpdateAsync(CityUpdateRequest request, string token);
    Task<Response<bool>> Delete(Guid cityDetailId, string token);
}