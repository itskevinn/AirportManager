using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain.Constants.Enum;
using Domain.Entities.Base;

namespace Domain.Entities;

public class Flight : Entity<Guid>
{
    [JsonIgnore] [NotMapped] public Airline Airline { get; set; } = default!;
    public string CheckInTime { get; set; } = default!;
    public string CheckOutTime { get; set; } = default!;
    public Guid DepartureCityId { get; set; }
    public Guid DestinyCityId { get; set; }
    [JsonIgnore] [NotMapped] public City? DepartureCity { get; set; } = default!;
    [JsonIgnore] [NotMapped] public City? DestinyCity { get; set; } = default!;
    public DateTime CheckOutDate { get; set; }
    public FlightStatus FlightStatus { get; set; }
}