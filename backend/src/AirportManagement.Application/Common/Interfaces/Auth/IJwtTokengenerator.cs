namespace AirportManagement.Application.Common.Interfaces.Auth;

public interface IJwtTokengenerator
{
    string GenerateToken(int userId, string firsName, string lastName);
}