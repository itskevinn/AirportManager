﻿using System.ComponentModel.DataAnnotations;

namespace Application.Security.Http.Request;

public class AuthenticateRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}