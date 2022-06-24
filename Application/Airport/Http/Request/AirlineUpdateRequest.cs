namespace Application.Airport.Http.Request;

public class AirlineUpdateRequest
{
	public Guid Id { get; set; }
	public string Name { get; set; } = default!;
	public string UpdatedBy { get; set; } = default!;

}