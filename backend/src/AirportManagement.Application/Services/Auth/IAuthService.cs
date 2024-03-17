using ErrorOr;

namespace AirportManagement.Application.Services.Auth;

public interface IAuthService
{
    Task<ErrorOr<AuthResult>> Register(string firstName, string lastName, string email, string password);
    Task<ErrorOr<AuthResult>> Login(string email, string password);
}