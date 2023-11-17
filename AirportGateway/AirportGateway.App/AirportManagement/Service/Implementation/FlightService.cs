using System.Net;
using AirportGateway.App.AirportManagement.Http.Dto;
using AirportGateway.App.AirportManagement.Http.Request;
using AirportGateway.App.AirportManagement.RestEaseClients;
using AirportGateway.App.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AirportGateway.App.AirportManagement.Service.Implementation;

/// <summary>
/// Class representing the implementation of the <see cref="IFlightService"/> interface
/// </summary>
public class FlightService : BaseService, IFlightService
{
    private readonly IFlightRestEaseClient _flightRestEaseClient;
    private readonly ILogger<FlightService> _logger;

    public FlightService(ILogger<FlightService> logger,
        IHttpContextAccessor accessor) : base(accessor)

    {
        _flightRestEaseClient =
            RestEase.RestClient.For<IFlightRestEaseClient>(ConfigMap.GetConfiguration()["airport-manager-service-url"]);
        _logger = logger;
    }

    public async Task<Response<IEnumerable<FlightDto>>> GetAllAsync(string token)
    {
        try
        {
            return await _flightRestEaseClient.GetAllAsync(token);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "{AnErrorHappenedMessage} {EMessage}", AnErrorHappenedMessage, e.Message);
            return new Response<IEnumerable<FlightDto>>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage,
                false, new List<FlightDto>(), e);
        }
    }


    public async Task<Response<FlightDto>> GetByIdAsync(Guid id, string token)
    {
        try
        {
            return await _flightRestEaseClient.GetByIdAsync(id, token);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "{AnErrorHappenedMessage} {EMessage}", AnErrorHappenedMessage, e.Message);
            return new Response<FlightDto>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage,
                false, new FlightDto(), e);
        }
    }

    public async Task<Response<FlightDto>> CreateAsync(FlightRequest request, string token)
    {
        try
        {
            return await _flightRestEaseClient.CreateAsync(request, token);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "{AnErrorHappenedMessage} {EMessage}", AnErrorHappenedMessage, e.Message);
            return new Response<FlightDto>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage,
                false, new FlightDto(), e);
        }
    }

    public async Task<Response<FlightDto>> Update(FlightUpdateRequest request, string token)
    {
        try
        {
            return await _flightRestEaseClient.Update(request, token);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "{AnErrorHappenedMessage} {EMessage}", AnErrorHappenedMessage, e.Message);
            return new Response<FlightDto>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage,
                false, new FlightDto(), e);
        }
    }

    public async Task<Response<bool>> UpdateStatusAsync(string newState, int code, string token)
    {
        try
        {
            return await _flightRestEaseClient.UpdateStatusAsync(newState, code, token);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "{AnErrorHappenedMessage} {EMessage}", AnErrorHappenedMessage, e.Message);
            return new Response<bool>(HttpStatusCode.InternalServerError, AnErrorHappenedMessage,
                false, false, e);
        }
    }
}