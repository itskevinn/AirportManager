using System.Net;
using AirportGateway.App.AirportManagement.Http.Dto;
using AirportGateway.App.AirportManagement.Http.Request;
using AirportGateway.App.AirportManagement.RestEaseClients;
using AirportGateway.App.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AirportGateway.App.AirportManagement.Service.Implementation;

/// <summary>
/// Class representing the implementation of the <see cref="IAirlineService"/> interface
/// </summary>
public class AirlineService : BaseService, IAirlineService
{
    private readonly IAirlineRestEaseClient _airlineRestEaseClient;
    private readonly ILogger<AirlineService> _logger;

    public AirlineService(ILogger<AirlineService> logger,
        IHttpContextAccessor accessor) :
        base(accessor)
    {
        _airlineRestEaseClient =
            RestEase.RestClient.For<IAirlineRestEaseClient>(ConfigMapService.GetConfiguration()["airport-manager-service-url"]);
        _logger = logger;
    }


    public async Task<Response<AirlineDto>> CreateAsync(AirlineRequest airlineRequest, string token)
    {
        try
        {
            var airlineDto = await _airlineRestEaseClient.CreateAsync(airlineRequest, token);
            return new Response<AirlineDto>(HttpStatusCode.OK, "Aereolínea registrada", true, airlineDto.Data);
        }
        catch (Exception e)
        {
            return new Response<AirlineDto>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false, null!,
                e);
        }
    }


    public async Task<Response<IEnumerable<AirlineDto>>> GetAllAsync(string token)
    {
        try
        {
            var airline = await _airlineRestEaseClient.GetAllAsync(token);
            return new Response<IEnumerable<AirlineDto>>(HttpStatusCode.OK, "Found airlines", true,
                airline.Data);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "{AnErrorHappenedMessage} {EMessage}", AnErrorHappenedMessage, e.Message);
            return new Response<IEnumerable<AirlineDto>>(HttpStatusCode.InternalServerError,
                AnErrorHappenedMessage,
                false, null!, e);
        }
    }


    public async Task<Response<AirlineDto>> UpdateAsync(AirlineUpdateRequest airlineUpdateRequest, string token)
    {
        try
        {
            var airlineDto = await _airlineRestEaseClient.UpdateAsync(airlineUpdateRequest, token);
            return new Response<AirlineDto>(HttpStatusCode.OK, "Aereolínea actualizada", true, airlineDto.Data);
        }
        catch (Exception e)
        {
            return new Response<AirlineDto>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false, null!,
                e);
        }
    }

    public async Task<Response<bool>> Delete(Guid id, string token)
    {
        try
        {
            var airlineDto = await _airlineRestEaseClient.Delete(id, token);
            return new Response<bool>(HttpStatusCode.OK, "Aereolínea registrada", true, airlineDto.Data);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage, false, false,
                e);
        }
    }
}