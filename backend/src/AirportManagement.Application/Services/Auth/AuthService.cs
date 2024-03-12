using AirportManagement.Application.Common.Interfaces.Auth;
using AirportManagement.Application.Common.Interfaces.Persistence.Users;
using AirportManagement.Domain.Entities;
using ErrorOr;

namespace AirportManagement.Application.Services.Auth;

public class AuthService(IJwtTokengenerator jwtTokengenerator, IUserRepository userRepository) : IAuthService
{
    private readonly IUserRepository _userRepository = userRepository;

    public ErrorOr<AuthResult> Register(string firstName, string lastName, string email, string password)
    {
        //check if user exists
        if (_userRepository.GetByEmailAsync(email) is not null)
            return Error.Conflict(description: "User already exists");

        //create a user(generate unique id)
        var user = new User(firstName, lastName, email, password);
        _userRepository.AddAsync(user);

        //generate token
        var token = jwtTokengenerator.GenerateToken(user.Id, firstName, lastName);

        return new AuthResult(user.Id, email, firstName, lastName, token);
    }

    public ErrorOr<AuthResult> Login(string email, string password)
    {
        //Validate user exists
        if (_userRepository.GetByEmailAsync(email) is not User user)
            return Error.Custom(400, "User does not exist", "Invalid email");

        if (user.Password != password)
            return Error.Custom(400, "Invalid password", "Invalid password"

        var token = jwtTokengenerator.GenerateToken(user.Id, "John", "Doe");
        return new AuthResult(user.Id, user.FirstName, user.Lastname, user.Email, token);
    }
}