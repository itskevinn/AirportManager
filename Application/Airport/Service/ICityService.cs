using Application.Airport.Http.Dto;
using Application.Airport.Http.Request;
using Application.Common.Response;

namespace Application.Airport.Service;

public interface ICityService : ITransientService
{
    Task<Response<CityDto>> SaveAsync(CityRequest cityRequest);
    Task<Response<bool>> SaveAllAsync(IEnumerable<CityRequest> cityRequests);
    Task<Response<IEnumerable<CityDto>>> GetAllAsync();
    Task<Response<CityDto>> GetByIdAsync(Guid id);
    Task<Response<bool>> UpdateAsync(CityUpdateRequest cityUpdateRequest);
    Task<Response<bool>> DeleteAsync(Guid id);
}