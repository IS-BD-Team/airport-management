using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using AirportManagement.Domain.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Clients.Commands.CreateClient;

public class CreateClientCommandHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateClientCommand, ErrorOr<Client>>
{
    private readonly IClientRepository _clientRepository = clientRepository;


    public async Task<ErrorOr<Client>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        if (!ArrivalRole.TryFromName(request.ArrivalRole, out var arrivalRole))
            return Error.Custom(400, "ArrivalRoleNotFound", $"Arrival role {request.ArrivalRole} not found.");

        if (!ClientType.TryFromName(request.ClientType, out var clientType))
            return Error.Custom(400, "ArrivalRoleNotFound", $"Arrival role {request.ArrivalRole} not found.");

        var client = new Client(request.Name, request.Ci, request.Country, arrivalRole, clientType);

        await _clientRepository.AddAsync(client);

        await unitOfWork.CommitChangesAsync();

        return client;
    }
}