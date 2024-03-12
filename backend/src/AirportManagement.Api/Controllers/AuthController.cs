using AirportManagement.Application.Services.Auth;
using AirportManagement.Contracts.Auth;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagement.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost]
    [Route("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );
        var authResponse = new AuthResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token
        );
        return Ok(authResponse);
    }

    [HttpGet]
    [Route("login")]
    public IActionResult SignIn(LoginReqest request)
    {
        var loginResult = _authService.Login(request.email, request.password);

        var authResponse = new AuthResponse(
            loginResult.Id,
            loginResult.FirstName,
            loginResult.LastName,
            loginResult.Email,
            loginResult.Token
        );
        return Ok(authResponse);
    }
}