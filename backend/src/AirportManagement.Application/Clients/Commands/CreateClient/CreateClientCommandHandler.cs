using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using AirportManagement.Domain.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Clients.Commands.CreateClient;

public class CreateClientCommandHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateClientCommand, ErrorOr<Client>>
{
    public async Task<ErrorOr<Client>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        if (!ArrivalRoleEnum.TryFromName(request.ArrivalRole, out var arrivalRole))
            return Error.Custom(400, "ArrivalRoleNotFound", $"Arrival role {request.ArrivalRole} not found.");

        if (!ClientTypeEnum.TryFromName(request.ClientType, out var clientType))
            return Error.Custom(400, "ArrivalRoleNotFound", $"Arrival role {request.ArrivalRole} not found.");

        var client = new Client(request.Name, request.Ci, request.Country, request.ArrivalRole, request.ClientType);

        await clientRepository.AddAsync(client);

        await unitOfWork.CommitChangesAsync();

        return client;
    }
}