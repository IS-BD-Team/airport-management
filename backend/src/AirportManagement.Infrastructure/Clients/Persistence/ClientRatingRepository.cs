using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using AirportManagement.Domain.Clients;
using AirportManagement.Infrastructure.Common.Persistence;
using ErrorOr;

namespace AirportManagement.Infrastructure.Clients.Persistence;

public class ClientRatingRepository(AirportManagementDbContext dbContext) : IClientRatingRepository
{
    public async Task<Success> AddAsync(ClientRating clientRating)
    {
        await dbContext.ClientRatings.AddAsync(clientRating);
        return new Success();
    }

    public Task<IQueryable<ClientRating>> GetAllAsync()
    {
        return Task.FromResult(dbContext.ClientRatings.AsQueryable());
    }

    public async Task<Success> DeleteAsync(int ratingId)
    {
        var clientRating = await dbContext.ClientRatings.FindAsync(ratingId);
        if (clientRating is null) throw new Exception("Client rating not found");
        dbContext.ClientRatings.Remove(clientRating);

        return new Success();
    }

    public async Task<ClientRating?> GetByIdAsync(int ratingId)
    {
        return await dbContext.ClientRatings.FindAsync(ratingId);
    }

    public async Task<ClientRating?> UpdateAsync(int clientRatingId, ClientRating clientRating)
    {
        var existingClientRating = await dbContext.ClientRatings.FindAsync(clientRatingId);

        if (existingClientRating != null)
        {
            existingClientRating.Rating = clientRating.Rating;
            dbContext.Update(existingClientRating);
        }

        return existingClientRating;
    }
}