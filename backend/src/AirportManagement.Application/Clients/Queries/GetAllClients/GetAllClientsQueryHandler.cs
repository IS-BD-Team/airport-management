using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using AirportManagement.Domain.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Clients.Queries.GetAllClients;

public class GetAllClientsQueryHandler(IClientRepository clientRepository)
    : IRequestHandler<GetAllClientsQuery, ErrorOr<IQueryable<Client>>>
{
    public async Task<ErrorOr<IQueryable<Client>>> Handle(GetAllClientsQuery request,
        CancellationToken cancellationToken)
    {
        var clients = await clientRepository.GetAllAsync();

        return clients.ToErrorOr();
    }
}