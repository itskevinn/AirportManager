using System.Net;
using AirportGateway.App.AirportManagement.Http.Dto;
using AirportGateway.App.AirportManagement.Http.Request;
using AirportGateway.App.AirportManagement.RestEaseClients;
using AirportGateway.App.Base;
using AirportGateway.App.Core.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AirportGateway.App.AirportManagement.Service.Implementation;

public class CityService : BaseService, ICityService
{
    private readonly ILogger<CityService> _logger;
    private readonly ICityRestEaseClient _cityRestEaseClient;

    public CityService(ILogger<CityService> logger, AppSettings appSettings,
        IHttpContextAccessor accessor) :
        base(accessor)
    {
        _logger = logger;
        _cityRestEaseClient =
            RestEase.RestClient.For<ICityRestEaseClient>(appSettings.MicroservicesUrls.FlightsManagementUrl);
    }


    public async Task<Response<IEnumerable<CityDto>>> GetAllAsync(string token)
    {
        try
        {
            var response = await _cityRestEaseClient.GetAll(token);
            return response;
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "{AnErrorHappenedMessage} {EMessage}", AnErrorHappenedMessage, e.Message);
            return new Response<IEnumerable<CityDto>>(HttpStatusCode.InternalServerError,
                AnErrorHappenedMessage,
                false, null!, e);
        }
    }

    public async Task<Response<CityDto>> GetByIdAsync(Guid cityId, string token)
    {
        try
        {
            var response = await _cityRestEaseClient.GetById(cityId, token);
            return response;
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "{AnErrorHappenedMessage} {EMessage}", AnErrorHappenedMessage, e.Message);
            return new Response<CityDto>(HttpStatusCode.InternalServerError,
                AnErrorHappenedMessage,
                false, null!, e);
        }
    }

    public async Task<Response<CityDto>> CreateAsync(CityRequest request, string token)
    {
        try
        {
            var response = await _cityRestEaseClient.CreateAsync(request, token);
            return response;
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "{AnErrorHappenedMessage} {EMessage}", AnErrorHappenedMessage, e.Message);
            return new Response<CityDto>(HttpStatusCode.InternalServerError,
                AnErrorHappenedMessage,
                false, null!, e);
        }
    }

    public async Task<Response<CityDto>> UpdateAsync(CityUpdateRequest request, string token)
    {
        try
        {
            var response = await _cityRestEaseClient.UpdateAsync(request, token);
            return response;
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "{AnErrorHappenedMessage} {EMessage}", AnErrorHappenedMessage, e.Message);
            return new Response<CityDto>(HttpStatusCode.InternalServerError,
                AnErrorHappenedMessage,
                false, null!, e);
        }
    }

    public async Task<Response<bool>> Delete(Guid cityId, string token)
    {
        try
        {
            var response = await _cityRestEaseClient.Delete(cityId, token);
            return response;
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "{AnErrorHappenedMessage} {EMessage}", AnErrorHappenedMessage, e.Message);
            return new Response<bool>(HttpStatusCode.InternalServerError,
                AnErrorHappenedMessage,
                false, false, e);
        }
    }
}