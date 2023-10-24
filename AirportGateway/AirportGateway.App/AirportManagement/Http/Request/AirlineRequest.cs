using System.ComponentModel.DataAnnotations;

namespace AirportGateway.App.AirportManagement.Http.Request;

public class AirlineRequest
{
    [Required] public string Name { get; set; }= default!;
    [Required] public string CreatedBy { get; set; } = default!;
}