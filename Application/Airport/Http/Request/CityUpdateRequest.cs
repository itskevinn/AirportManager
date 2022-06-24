using System.ComponentModel.DataAnnotations;

namespace Application.Airport.Http.Request;

public class CityUpdateRequest
{
	public Guid Id { get; set; }
	public bool Status { get; set; }
	[Required] public string Name { get; set; } = default!;
	[Required] public string UpdatedBy { get; set; } = default!;
	public string CreatedBy { get; set; } = default!;
}