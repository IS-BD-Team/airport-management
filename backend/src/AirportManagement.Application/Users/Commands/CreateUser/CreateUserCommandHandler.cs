using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Users;
using AirportManagement.Domain.Entities;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateUserCommand, ErrorOr<User>>
{
    public async Task<ErrorOr<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.FirstName, request.LastName, request.Email, request.Password);

        await userRepository.AddAsync(user);
        await unitOfWork.CommitChangesAsync();

        return user;
    }
}