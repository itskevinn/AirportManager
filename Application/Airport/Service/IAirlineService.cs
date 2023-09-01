using Application.Airport.Http.Dto;
using Application.Airport.Http.Request;
using Infrastructure.Common.Interface;
using Infrastructure.Common.Response;

namespace Application.Airport.Service;

public interface IAirlineService : ITransientService
{
    Task<Response<AirlineDto>> SaveAsync(AirlineRequest airlineRequest);
    Task<Response<IEnumerable<AirlineDto>>> GetAllAsync();
    Task<Response<AirlineDto>> GetByIdAsync(Guid id);
    Task<Response<AirlineDto>> UpdateAsync(AirlineUpdateRequest airlineUpdateRequest);
    Task<Response<bool>> DeleteAsync(Guid id);
}