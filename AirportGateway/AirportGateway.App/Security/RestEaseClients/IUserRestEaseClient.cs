using AirportGateway.App.Security.Http.Dto;
using AirportGateway.App.Security.Http.Request;
using RestEase;

namespace AirportGateway.App.Security.RestEaseClients;

public interface IUserRestEaseClient
{
    [Get("api/v1/User/FindById/{id}")]
    public Task<Base.Response<UserDto>> GetById([Path] Guid id, [Header("Authorization")] string authorization);

    [Get("api/v1/User/FindAll")]
    public Task<Base.Response<IEnumerable<UserDto>>> GetAll([Header("Authorization")] string authorization);

    [Post("api/v1/User/Create")]
    public Task<Base.Response<UserDto>> Save(UserRequest userRequest, [Header("Authorization")] string authorization);
}