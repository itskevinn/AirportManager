using System.ComponentModel.DataAnnotations;

namespace AirportGateway.App.Security.Http.Request;

public class AuthenticateRequest
{
    [Required]
    public string Username { get; set; } = default!;

    [Required]
    public string Password { get; set; } = default!;
}