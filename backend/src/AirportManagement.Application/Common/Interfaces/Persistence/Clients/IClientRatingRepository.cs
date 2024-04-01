using ErrorOr;

namespace AirportManagement.Application.Common.Interfaces.Persistence.Clients;

public interface IClientRatingRepository
{
    Task<Success> AddAsync(Domain.Clients.ClientRating clientRating);
    Task<Success> DeleteAsync(int clientRatingId);
    Task<Domain.Clients.ClientRating?> UpdateAsync(int clientRatingId, Domain.Clients.ClientRating clientRating);
    Task<Domain.Clients.ClientRating?> GetByIdAsync(int clientRatingId);
    Task<IQueryable<Domain.Clients.ClientRating>> GetAllAsync();
}