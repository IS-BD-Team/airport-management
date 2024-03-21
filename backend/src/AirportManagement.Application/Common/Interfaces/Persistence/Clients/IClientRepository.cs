using AirportManagement.Domain.Clients;

namespace AirportManagement.Application.Common.Interfaces.Persistence.Clients;

/// <summary>
///     Interface for the Client Repository.
///     Provides methods for adding, deleting, updating and retrieving clients.
/// </summary>
public interface IClientRepository
{
    /// <summary>
    ///     Asynchronously adds a new client to the repository.
    /// </summary>
    /// <param name="client">The client to add.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    Task AddAsync(Client client);

    /// <summary>
    ///     Asynchronously deletes a client from the repository.
    /// </summary>
    /// <param name="clientId">The ID of the client to delete.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    Task<Client?> DeleteAsync(int clientId);

    /// <summary>
    ///     Asynchronously retrieves a client by ID from the repository.
    /// </summary>
    /// <param name="clientId">The ID of the client to retrieve.</param>
    /// <returns>A Task resulting in the client, if found, or null.</returns>
    Task<Client?> GetByIdAsync(int clientId);

    /// <summary>
    ///     Asynchronously updates a client in the repository.
    /// </summary>
    /// <param name="clientId">The ID of the client to update.</param>
    /// <param name="newClientData">The updated client information.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    Task<Client?> UpdateAsync(int clientId, Client newClientData);

    /// <summary>
    ///     Asynchronously retrieves all clients from the repository.
    /// </summary>
    /// <returns>A Task resulting in a collection of all clients, or null if none exist.</returns>
    Task<IEnumerable<Client>> GetAllAsync();
}