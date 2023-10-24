using Application.Http.Request;

namespace Application.Http.Dto;

public class FlightDto : FlightRequest
{
    public AirlineDto Airline { get; set; } = default!;
    public CityDto DepartureCity { get; set; } = default!;
    public CityDto DestinyCity { get; set; } = default!;
}