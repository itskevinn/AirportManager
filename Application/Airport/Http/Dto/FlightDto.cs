﻿using Application.Airport.Http.Request;
using Domain.Constants.Enum;

namespace Application.Airport.Http.Dto;

public class FlightDto : FlightRequest
{
    public AirlineDto Airline { get; set; } = default!;
    public CityDto DepartureCity { get; set; } = default!;
    public CityDto DestinyCity { get; set; } = default!;
}