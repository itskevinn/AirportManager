using AirportGateway.App.AirportManagement.Http.Dto;
using AirportGateway.App.AirportManagement.Http.Request;
using AirportGateway.App.Exceptions;
using RestEase;

namespace AirportGateway.App.AirportManagement.RestEaseClients;

public interface IFlightRestEaseClient
{
    /// <summary>
    /// Method that retrieves all flights registered in the database
    /// </summary>
    /// <returns cref="FlightDto">An enumerable of the flights found in database <see cref="Response{T}"/> <see cref="IEnumerable{T}"/> <see cref="FlightDto"/></returns>
    [Get("api/v1/Flight/All")]
    Task<Base.Response<IEnumerable<FlightDto>>> GetAllAsync([Header("Authorization")] string token);

    /// <summary>
    /// Method that finds the flight associated with the specified id in the database
    /// </summary>
    /// <param name="id">Id of the flight to search for</param>
    /// <param name="token">Auth token</param>
    /// <returns cref="FlightDto">dto of the flight found in database <see cref="Response{T}"/> <see cref="FlightDto"/></returns>
    [Get("api/v1/Flight/GetById/{id}")]
    Task<Base.Response<FlightDto>> GetByIdAsync([Path("id")] Guid id,
        [Header("Authorization")] string token);

    /// <summary>
    /// Method used to validate and save the flight
    /// </summary>
    /// <param name="token">Auth token</param>
    /// <param cref="FlightRequest" name="request">Flight request sent from client</param>
    /// <returns> Saved flight <see cref="Response{T}"/> <see cref="FlightDto"/></returns>
    /// <exception cref="UserNotFoundException"></exception>
    [Post("api/v1/Flight/Create")]
    Task<Base.Response<FlightDto>> CreateAsync([Body] FlightRequest request,
        [Header("Authorization")] string token);

    /// <summary>
    /// Method used to updating the flight
    /// </summary>
    /// <param cref="FlightUpdateRequest" name="request">Flight request sent from client</param>
    /// <param name="token">Auth token</param>
    /// <returns> Saved flight <see cref="Response{T}"/> <see cref="FlightDto"/></returns>
    /// <exception cref="UserNotFoundException"></exception>
    [Put("api/v1/Flight/Update")]
    Task<Base.Response<FlightDto>> Update([Body] FlightUpdateRequest request,
        [Header("Authorization")] string token);

    /// <summary>
    /// Method used to updating the flight
    /// </summary>
    /// 
    /// <param name="id">Id of the flight to update status</param>
    /// <param name="newState">New status for the flight</param>
    /// <param name="token">Auth token</param>
    /// <returns> Saved flight <see cref="Response{T}"/> <see cref="FlightDto"/></returns>
    /// <exception cref="UserNotFoundException"></exception>
    [Patch("api/v1/Flight/UpdateStatus?id={id}&newState={newState}")]
    Task<Base.Response<bool>> UpdateStatusAsync([Path("newState")] string newState, [Path("id")] int id,
        [Header("Authorization")] string token);

}