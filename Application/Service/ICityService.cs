using Application.Base;
using Application.Http.Dto;
using Application.Http.Request;
using Infrastructure.Core.Interface;

namespace Application.Service;

public interface ICityService : ITransientService
{
    Task<Response<CityDto>> SaveAsync(CityRequest cityRequest);
    Task<Response<bool>> SaveAllAsync(IEnumerable<CityRequest> cityRequests);
    Task<Response<IEnumerable<CityDto>>> GetAllAsync();
    Task<Response<CityDto>> GetByIdAsync(Guid id);
    Task<Response<bool>> UpdateAsync(CityUpdateRequest cityUpdateRequest);
    Task<Response<bool>> DeleteAsync(Guid id);
}