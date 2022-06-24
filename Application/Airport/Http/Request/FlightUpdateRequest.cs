using System.ComponentModel.DataAnnotations;

namespace Application.Airport.Http.Request;

public class FlightUpdateRequest
{
	public Guid Id { get; set; }
	public Guid AirlineId { get; set; }
	public string CheckInTime { get; set; } = default!;
	public string CheckOutTime { get; set; } = default!;
	public Guid DepartureCityId { get; set; }
	public Guid DestinyCityId { get; set; }
	public DateTime CheckOutDate { get; set; }
	[Required] public string UpdatedBy { get; set; } = default!;
}