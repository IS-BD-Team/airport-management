using AirportManagement.Domain.Entities;

namespace AirportManagement.Application.Common.Interfaces.Auth;

public interface IJwtTokengenerator
{
    string GenerateToken(User user);
}