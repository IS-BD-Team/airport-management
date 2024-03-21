using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using AirportManagement.Domain.Clients;
using ErrorOr;

namespace AirportManagement.Application.Clients.Commands.CreateClient;

public class CreateClientCommandHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork)
{
    private readonly IClientRepository _clientRepository = clientRepository;


    public async Task<ErrorOr<Client>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = new Client(request.Name, request.Ci, request.Country, request.ArrivalRole, request.ClientType);

        await _clientRepository.AddAsync(client);

        await unitOfWork.CommitChangesAsync();

        return client;
    }
}