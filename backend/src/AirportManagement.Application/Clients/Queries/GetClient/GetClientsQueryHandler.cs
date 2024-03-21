using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using AirportManagement.Domain.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Clients.Queries.GetClient;

public class GetClientsQueryHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<GetClientsQuery, ErrorOr<IEnumerable<Client>>>
{
    public async Task<ErrorOr<IEnumerable<Client>>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        var clients = await clientRepository.GetAllAsync();

        return clients.ToList();
    }
}