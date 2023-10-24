using AirportGateway.App.AirportManagement.Http.Dto;
using AirportGateway.App.AirportManagement.Http.Request;
using AirportGateway.App.Base;
using AirportGateway.App.Core.Interface;
using AirportGateway.App.Exceptions;

namespace AirportGateway.App.AirportManagement.Service;

public interface IFlightService : ITransientService
{
    /// <summary>
    /// Method that retrieves all flights registered in the database
    /// </summary>
    /// <returns cref="FlightDto">An enumerable of the flights found in database <see cref="Response{T}"/> <see cref="IEnumerable{T}"/> <see cref="FlightDto"/></returns>
    Task<Response<IEnumerable<FlightDto>>> GetAllAsync(string token);

    /// <summary>
    /// Method that finds the flight associated with the specified code in the database
    /// </summary>
    /// <param name="id">Id of the flight to search for</param>
    /// <param name="token">Auth token</param>
    /// <returns cref="FlightDto">dto of the flight found in database <see cref="Response{T}"/> <see cref="FlightDto"/></returns>
    Task<Response<FlightDto>> GetByIdAsync(Guid id, string token);

    /// <summary>
    /// Method used to validate and call db to save the flight
    /// </summary>
    /// <param cref="FlightRequest" name="request">Flight request sent from client</param>
    /// <param name="token">Auth token</param>
    /// <returns> Saved flight <see cref="Response{T}"/> <see cref="FlightDto"/></returns>
    /// <exception cref="UserNotFoundException"></exception>
    Task<Response<FlightDto>> CreateAsync(FlightRequest request, string token);

    /// <summary>
    /// Method used to updating the flight
    /// </summary>
    /// <param cref="UpdateFlightRequest" name="request">Flight request sent from client</param>
    /// <param name="token">Auth token</param>
    /// <returns> Saved flight <see cref="Response{T}"/> <see cref="FlightDto"/></returns>
    /// <exception cref="UserNotFoundException"></exception>
    Task<Response<FlightDto>> Update(FlightUpdateRequest request, string token);
}