using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using AirportManagement.Domain.Clients;
using AirportManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Infrastructure.Clients.Persistence;

public class ClientRepository(AirportManagementDbContext dbContext) : IClientRepository
{
    public async Task AddAsync(Client client)
    {
        await dbContext.Clients.AddAsync(client);
    }

    public async Task<Client?> DeleteAsync(int clientId)
    {
        var client = await dbContext.Clients.FindAsync(clientId);
        if (client != null) dbContext.Clients.Remove(client);

        return client;
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

    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await dbContext.Clients.ToListAsync();
    }
}