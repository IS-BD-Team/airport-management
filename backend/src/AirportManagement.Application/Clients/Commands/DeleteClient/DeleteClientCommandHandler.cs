using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using AirportManagement.Domain.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Clients.Commands.DeleteClient;

public class DeleteClientCommandHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteClientCommand, ErrorOr<Client>>
{
    public async Task<ErrorOr<Client>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var client = await clientRepository.DeleteAsync(request.ClientId);
        await unitOfWork.CommitChangesAsync();

        return client is null
            ? Error.NotFound($"Client with id: {request.ClientId} was not found.")
            : client;
    }
}