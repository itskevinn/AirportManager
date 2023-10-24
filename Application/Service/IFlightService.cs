using Application.Base;
using Application.Http.Dto;
using Application.Http.Request;
using Infrastructure.Core.Interface;

namespace Application.Service;

public interface IFlightService : ITransientService
{
    Task<Response<FlightDto>> SaveAsync(FlightRequest flightRequest);
    Task<Response<IEnumerable<FlightDto>>> GetAllAsync();
    Task<Response<FlightDto>> GetByIdAsync(Guid id);
    Task<Response<bool>> UpdateAsync(FlightUpdateRequest flightUpdateRequest);
    Task<Response<bool>> DeleteAsync(Guid id);
}