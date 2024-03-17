using AirportManagement.Domain.Entities;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Users.Commands.CreateUser;

public record CreateUserCommand(string FirstName, string LastName, string Email, string Password)
    : IRequest<ErrorOr<User>>;