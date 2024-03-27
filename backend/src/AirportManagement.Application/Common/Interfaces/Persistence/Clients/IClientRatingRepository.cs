namespace AirportManagement.Application.Common.Interfaces.Persistence.Clients;

public interface IClientRatingRepository
{
    Task AddAsync(Domain.Clients.ClientRating clientRating);
    Task<Domain.Clients.ClientRating?> DeleteAsync(int clientRatingId);
    Task<Domain.Clients.ClientRating?> UpdateAsync(int clientRatingId, Domain.Clients.ClientRating clientRating);
    Task<Domain.Clients.ClientRating?> GetByIdAsync(int clientRatingId);
    Task<IEnumerable<Domain.Clients.ClientRating>> GetAllAsync();
}