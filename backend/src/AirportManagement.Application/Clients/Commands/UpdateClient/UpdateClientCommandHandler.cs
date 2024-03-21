using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using AirportManagement.Domain.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Clients.Commands.UpdateClient;

public class UpdateClientCommandHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateClientCommand, ErrorOr<Client>>
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<ErrorOr<Client>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var newClientData = new Client(request.Name, request.Ci, request.Country, request.ArrivalRole,
            request.ClientType);

        var client = await _clientRepository.UpdateAsync(request.Id, newClientData);

        if (client is null) return Error.NotFound($"Client with id: {request.Id} was not found");

        await unitOfWork.CommitChangesAsync();

        return client;
    }
}