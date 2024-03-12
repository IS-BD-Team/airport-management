namespace AirportManagement.Contracts.Auth;

public record AuthResponse(int Id, string FirstName, string LastName, string Email, string Token);