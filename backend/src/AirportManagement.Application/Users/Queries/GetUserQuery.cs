using AirportManagement.Domain.Entities;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Users.Queries;

public record GetUserQuery(string Email)
    : IRequest<ErrorOr<User>>;