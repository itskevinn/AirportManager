using Application.Airport.Http.Dto;
using Application.Airport.Http.Request;
using Infrastructure.Common.Response;

namespace Application.Airport.Service;

public interface IFlightService : ITransientService
{
    Task<Response<FlightDto>> SaveAsync(FlightRequest flightRequest);
    Task<Response<IEnumerable<FlightDto>>> GetAllAsync();
    Task<Response<FlightDto>> GetByIdAsync(Guid id);
    Task<Response<bool>> UpdateAsync(FlightUpdateRequest flightUpdateRequest);
    Task<Response<bool>> DeleteAsync(Guid id);
}