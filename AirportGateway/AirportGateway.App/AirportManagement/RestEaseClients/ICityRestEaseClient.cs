using AirportGateway.App.AirportManagement.Http.Dto;
using AirportGateway.App.AirportManagement.Http.Request;
using RestEase;

namespace AirportGateway.App.AirportManagement.RestEaseClients;

public interface ICityRestEaseClient
{
    [Get("api/v1/City/GetAll")]
    Task<Base.Response<IEnumerable<CityDto>>> GetAll([Header("Authorization")] string token);

    [Get("api/v1/City/GetById/{id:guid}")]
    Task<Base.Response<CityDto>> GetById([Path] Guid cityId, [Header("Authorization")] string token);

    [Post("api/v1/City/Create")]
    Task<Base.Response<CityDto>> CreateAsync([Body] CityRequest request, [Header("Authorization")] string token);

    [Put("api/v1/City/Update")]
    Task<Base.Response<CityDto>> UpdateAsync([Body] CityUpdateRequest request, [Header("Authorization")] string token);

    [Delete("api/v1/City/Delete/{id:guid}")]
    Task<Base.Response<bool>> Delete([Path] Guid id, [Header("Authorization")] string token);
}