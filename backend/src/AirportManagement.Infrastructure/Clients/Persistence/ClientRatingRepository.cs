using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using AirportManagement.Domain.Clients;
using AirportManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Infrastructure.Clients.Persistence;

public class ClientRatingRepository(AirportManagementDbContext dbContext) : IClientRatingRepository
{
    public async Task AddAsync(ClientRating clientRating)
    {
        await dbContext.ClientRatings.AddAsync(clientRating);
    }

    public async Task<IEnumerable<ClientRating>> GetAllAsync()
    {
        return await dbContext.ClientRatings.ToListAsync();
    }

    public async Task<ClientRating?> DeleteAsync(int ratingId)
    {
        var clientRating = await dbContext.ClientRatings.FindAsync(ratingId);
        if (clientRating != null)
        {
            dbContext.ClientRatings.Remove(clientRating);
            await dbContext.SaveChangesAsync();
        }

        return clientRating;
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