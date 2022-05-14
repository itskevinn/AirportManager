namespace Application.Airport.Http.Request;

public class FlightUpdateRequest : FlightRequest
{
    public Guid Id { get; set; }
    public string UpdatedBy { get; set; } = default!;
    public DateTime LastModifiedOn { get; set; } = default!;
}