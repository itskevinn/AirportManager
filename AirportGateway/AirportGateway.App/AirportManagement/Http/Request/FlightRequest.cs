﻿using System.ComponentModel.DataAnnotations;
using AirportGateway.App.AirportManagement.Http.Enum;

namespace AirportGateway.App.AirportManagement.Http.Request;

public class FlightRequest
{
    public Guid AirlineId { get; set; }
    public string CheckInTime { get; set; } = default!;
    public string CheckOutTime { get; set; } = default!;
    public Guid DepartureCityId { get; set; }
    public Guid DestinyCityId { get; set; }
    public DateTime CheckOutDate { get; set; }
    public FlightStatus FlightStatus { get; set; } = default!;
    [Required] public string CreatedBy { get; set; } = default!;
}