using System.Net;
using AirportGateway.App.Base;
using AirportGateway.App.Security.Http.Dto;
using AirportGateway.App.Security.Http.Request;
using AirportGateway.App.Security.RestEaseClients;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AirportGateway.App.Security.Services.Implementation;

public class UserService : BaseService, IUserService
{
    private readonly IUserRestEaseClient _userRestEaseClient;
    private readonly ILogger<UserService> _logger;

    public UserService(ILogger<UserService> logger,
        IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _userRestEaseClient =
            RestEase.RestClient.For<IUserRestEaseClient>(ConfigMap.GetConfiguration()["airport-security-service-url"]);
    }

    public async Task<Response<UserDto>> GetById(Guid id, string token)
    {
        try
        {
            return await _userRestEaseClient.GetById(id, token);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "{AnErrorHappenedMessage} {EMessage}", AnErrorHappenedMessage, e.Message);
            return new Response<UserDto>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false, null!, e);
        }
    }

    public async Task<Response<IEnumerable<UserDto>>> GetAll(string token)
    {
        try
        {
            return await _userRestEaseClient.GetAll(token);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "{AnErrorHappenedMessage} {EMessage}", AnErrorHappenedMessage, e.Message);
            return new Response<IEnumerable<UserDto>>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false,
                null!, e);
        }
    }

    public async Task<Response<UserDto>> Save(UserRequest userRequest, string token)
    {
        try
        {
            return await _userRestEaseClient.Save(userRequest, token);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "{AnErrorHappenedMessage} {EMessage}", AnErrorHappenedMessage, e.Message);
            return new Response<UserDto>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false,
                null!, e);
        }
    }
}