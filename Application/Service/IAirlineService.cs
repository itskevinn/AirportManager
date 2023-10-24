using Application.Base;
using Application.Http.Dto;
using Application.Http.Request;
using Infrastructure.Core.Interface;

namespace Application.Service;

public interface IAirlineService : ITransientService
{
    Task<Response<AirlineDto>> SaveAsync(AirlineRequest airlineRequest);
    Task<Response<IEnumerable<AirlineDto>>> GetAllAsync();
    Task<Response<AirlineDto>> GetByIdAsync(Guid id);
    Task<Response<AirlineDto>> UpdateAsync(AirlineUpdateRequest airlineUpdateRequest);
    Task<Response<bool>> DeleteAsync(Guid id);
}