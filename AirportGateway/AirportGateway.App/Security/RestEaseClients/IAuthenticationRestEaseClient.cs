using AirportGateway.App.Security.Http.Dto;
using AirportGateway.App.Security.Http.Request;
using RestEase;

namespace AirportGateway.App.Security.RestEaseClients;

public interface IAuthenticationRestEaseClient
{
    [Post("api/v1/Auth/Authenticate")]
    Task<Base.Response<AuthenticateDto>> AuthenticateAsync([Body] AuthenticateRequest authenticateRequest);
}