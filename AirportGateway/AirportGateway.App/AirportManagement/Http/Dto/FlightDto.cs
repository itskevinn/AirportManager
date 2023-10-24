using AirportGateway.App.AirportManagement.Http.Request;

namespace AirportGateway.App.AirportManagement.Http.Dto;

public class FlightDto : FlightRequest
{
    public AirlineDto Airline { get; set; } = default!;
    public CityDto DepartureCity { get; set; } = default!;
    public CityDto DestinyCity { get; set; } = default!;
}