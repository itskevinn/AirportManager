using AirportGateway.App.AirportManagement.Http.Dto;
using AirportGateway.App.AirportManagement.Http.Request;
using RestEase;

namespace AirportGateway.App.AirportManagement.RestEaseClients;

public interface IAirlineRestEaseClient
{
    [Get("api/v1/Airline/GetAll")]
    Task<Base.Response<IEnumerable<AirlineDto>>> GetAllAsync([Header("Authorization")] string token);

    [Get("api/v1/Airline/GetById/{id}")]
    Task<Base.Response<AirlineDto>> GetById([Path("id")] Guid id, [Header("Authorization")] string token);

    [Post("api/v1/Airline/Create")]
    Task<Base.Response<AirlineDto>> CreateAsync([Body] AirlineRequest airlineRequest,
        [Header("Authorization")] string token);

    [Put("api/v1/Airline/Update")]
    Task<Base.Response<AirlineDto>> UpdateAsync([Body] AirlineUpdateRequest airlineRequest,
        [Header("Authorization")] string token);

    [Delete("api/v1/Airline/Delete/{id}")]
    Task<Base.Response<bool>> Delete([Path("id")] Guid id, [Header("Authorization")] string token);
}