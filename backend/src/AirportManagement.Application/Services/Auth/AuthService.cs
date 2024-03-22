using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Auth;
using AirportManagement.Application.Common.Interfaces.Persistence.Users;
using AirportManagement.Domain.Entities;
using ErrorOr;

namespace AirportManagement.Application.Services.Auth;

public class AuthService(IJwtTokengenerator jwtTokengenerator, IUserRepository userRepository, IUnitOfWork unitOfWork)
    : IAuthService
{
    public async Task<ErrorOr<AuthResult>> Register(string firstName, string lastName, string email, string password)
    {
        //check if user exists
        if (await userRepository.GetByEmailAsync(email) is not null)
            return Error.Conflict(description: "User already exists");

        //create a user(generate unique id)
        var user = new User(firstName, lastName, email, password);
        await userRepository.AddAsync(user);
        await unitOfWork.CommitChangesAsync();

        //generate token
        var token = jwtTokengenerator.GenerateToken(user);

        return new AuthResult(user, token);
    }

    public async Task<ErrorOr<AuthResult>> Login(string email, string password)
    {
        var user = await userRepository.GetByEmailAsync(email);
        //Validate user exists
        if (user is null)
            return Error.Custom(400, "User does not exist", "Invalid email");

        if (user.Password != password)
            return Error.Custom(400, "Invalid password", "Invalid password");

        var token = jwtTokengenerator.GenerateToken(user);
        return new AuthResult(user, token);
    }
}