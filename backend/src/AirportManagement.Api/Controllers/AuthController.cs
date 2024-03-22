using AirportManagement.Application.Services.Auth;
using AirportManagement.Contracts.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagement.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpGet]
    [Route("check")]
    [Authorize]
    public IActionResult Check()
    {
        return Ok();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var authResult = await authService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );

        return authResult.MatchFirst(result =>
                Ok(new AuthResponse
                (
                    result.User.Id,
                    result.User.FirstName,
                    result.User.Lastname,
                    result.User.Email,
                    result.Token
                )),
            error => Problem(error.Code, statusCode: error.NumericType));
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var loginResult = await authService.Login(request.Email, request.Password);

        return loginResult.MatchFirst(result =>
                Ok(new AuthResponse
                (
                    result.User.Id,
                    result.User.FirstName,
                    result.User.Lastname,
                    result.User.Email,
                    result.Token
                )),
            error => Problem(error.Code, statusCode: error.NumericType));
    }
}