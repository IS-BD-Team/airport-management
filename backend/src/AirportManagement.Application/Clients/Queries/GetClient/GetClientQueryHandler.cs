using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using AirportManagement.Domain.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Clients.Queries.GetClient;

public class GetClientQueryHandler(IClientRepository clientRepository)
    : IRequestHandler<GetClientQuery, ErrorOr<Client>>
{
    public async Task<ErrorOr<Client>> Handle(GetClientQuery request, CancellationToken cancellationToken)
    {
        var client = await clientRepository.GetByIdAsync(request.ClientId);

        if (client is null) return Error.NotFound($"Client with id {request.ClientId} not found");

        return client;
    }
}