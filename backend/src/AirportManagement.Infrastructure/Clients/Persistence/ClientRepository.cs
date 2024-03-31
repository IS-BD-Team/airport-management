using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using AirportManagement.Domain.Clients;
using AirportManagement.Infrastructure.Common.Persistence;
using ErrorOr;

namespace AirportManagement.Infrastructure.Clients.Persistence;

public class ClientRepository(AirportManagementDbContext dbContext) : IClientRepository
{
    public async Task<Success> AddAsync(Client client)
    {
        await dbContext.Clients.AddAsync(client);
        return new Success();
    }

    public async Task<Success> DeleteAsync(int clientId)
    {
        var client = await dbContext.Clients.FindAsync(clientId);
        if (client is null) throw new Exception("Client not found");

        dbContext.Clients.Remove(client);

        return new Success();
    }

    public async Task<Client?> GetByIdAsync(int clientId)
    {
        return await dbContext.Clients.FindAsync(clientId);
    }

    public async Task<Client?> UpdateAsync(int clientId, Client newClientData)
    {
        var existingClient = await dbContext.Clients.FindAsync(clientId);

        if (existingClient != null)
        {
            existingClient.Name = newClientData.Name;
            existingClient.Ci = newClientData.Ci;
            existingClient.Country = newClientData.Country;
            existingClient.ArrivalRole = newClientData.ArrivalRole;
            existingClient.ClientType = newClientData.ClientType;

            dbContext.Update(existingClient);
        }

        return existingClient;
    }

    public Task<IQueryable<Client>> GetAllAsync()
    {
        return Task.FromResult(dbContext.Clients.AsQueryable());
    }
}