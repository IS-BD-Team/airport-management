using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Clients.Commands.DeleteClient;

public class DeleteClientCommandHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteClientCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var result = await clientRepository.DeleteAsync(request.ClientId);
        await unitOfWork.CommitChangesAsync();

        return new Success();
    }
}