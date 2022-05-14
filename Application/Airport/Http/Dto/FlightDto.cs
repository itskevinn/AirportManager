using Application.Airport.Http.Request;
using Domain.Constants.Enum;

namespace Application.Airport.Http.Dto;

public class FlightDto : FlightRequest
{
    public AirlineDto AirlineDto { get; set; } = default!;
    public CityDto DepartureCityDto { get; set; } = default!;
    public CityDto DestinyCityDto { get; set; } = default!;
}