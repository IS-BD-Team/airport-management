using AirportManagement.Domain.Entities;

namespace AirportManagement.Application.Services.Auth;

public record AuthResult(
    User User,
    string Token
);