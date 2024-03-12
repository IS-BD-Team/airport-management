namespace AirportManagement.Application.Services.Auth;

public record AuthResult(
    int Id,
    string Email,
    string FirstName,
    string LastName,
    string Token
);