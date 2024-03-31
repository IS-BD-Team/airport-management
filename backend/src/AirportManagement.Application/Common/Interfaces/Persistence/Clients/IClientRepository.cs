using AirportManagement.Domain.Clients;
using ErrorOr;

namespace AirportManagement.Application.Common.Interfaces.Persistence.Clients;

public interface IClientRepository
{
    Task<Success> AddAsync(Client client);
    Task<Success> DeleteAsync(int clientId);
    Task<Client?> GetByIdAsync(int clientId);
    Task<Client?> UpdateAsync(int clientId, Client newClientData);
    Task<IQueryable<Client>> GetAllAsync();
}