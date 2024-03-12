using ErrorOr;

namespace AirportManagement.Application.Services.Auth;

public interface IAuthService
{
    ErrorOr<AuthResult> Register(string firstName, string lastName, string email, string password);
    ErrorOr<AuthResult> Login(string email, string password);
}