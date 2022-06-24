﻿using System.ComponentModel.DataAnnotations;

namespace Application.Airport.Http.Request;

public class AirlineRequest
{
    [Required] public string Name { get; set; }= default!;
    [Required] public string CreatedBy { get; set; } = default!;
}