using AirportGateway.App.AirportManagement.Http.Dto;
using AirportGateway.App.AirportManagement.Http.Request;
using AirportGateway.App.Base;
using AirportGateway.App.Core.Interface;

namespace AirportGateway.App.AirportManagement.Service;

public interface IAirlineService: ITransientService
{
    Task<Response<IEnumerable<AirlineDto>>> GetAllAsync(string token);
    Task<Response<bool>> Delete(Guid cityDetailId, string token);
    Task<Response<AirlineDto>> CreateAsync(AirlineRequest request, string token);
    Task<Response<AirlineDto>> UpdateAsync(AirlineUpdateRequest request, string token);
}