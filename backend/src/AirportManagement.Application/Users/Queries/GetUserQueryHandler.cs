using AirportManagement.Application.Common.Interfaces.Persistence.Users;
using AirportManagement.Domain.Entities;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Users.Queries;

public class GetUserQueryHandler(IUserRepository userRepository)
    : IRequestHandler<GetUserQuery, ErrorOr<User>>
{
    public async Task<ErrorOr<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(request.Email);
        return user is null ? Error.NotFound($"User with email: {request.Email} was not found.") : user;
    }
}