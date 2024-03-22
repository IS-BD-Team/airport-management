using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using AirportManagement.Domain.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Clients.Commands.UpdateClient;

public class UpdateClientCommandHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateClientCommand, ErrorOr<Client>>
{
    public async Task<ErrorOr<Client>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var arrivalRole = ArrivalRole.FromName(request.ArrivalRole);
        var clientType = ClientType.FromName(request.ClientType);

        var newClientData = new Client(request.Name, request.Ci, request.Country, arrivalRole, clientType);

        var client = await clientRepository.UpdateAsync(request.Id, newClientData);

        if (client is null) return Error.NotFound($"Client with id: {request.Id} was not found");

        await unitOfWork.CommitChangesAsync();

        return client;
    }
}