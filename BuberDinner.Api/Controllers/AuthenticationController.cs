﻿using BuberDinner.Contracts.Authentication;
using BuberDinner.Application.Services.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : Controller {

    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService) {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request) {

        AuthenticationResult authenticationResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        
        var response = new AuthenticationResponse(
            authenticationResult.User.Id,
            authenticationResult.User.FirstName,
            authenticationResult.User.LastName,
            authenticationResult.User.Email,
            authenticationResult.Token
        );
        return Ok(response);
    }

    [Route("login")]
    public IActionResult Login(LoginRequest request) {
        
        AuthenticationResult authenticationResult = _authenticationService.Login(request.Email, request.Password);
        
        var response = new AuthenticationResponse(
            authenticationResult.User.Id,
            authenticationResult.User.FirstName,
            authenticationResult.User.LastName,
            authenticationResult.User.Email,
            authenticationResult.Token
        );
        return Ok(response);
    }
}
