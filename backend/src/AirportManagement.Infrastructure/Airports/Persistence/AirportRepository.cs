using AirportManagement.Application.Common.Interfaces.Persistence.Airports;
using AirportManagement.Domain.Airports;
using AirportManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Infrastructure.Airports.Persistence;

public class AirportRepository(AirportManagementDbContext dbContext) : IAirportsRepository
{
    public async Task AddAirportAsync(Airport airport)
    {
        await dbContext.Airports.AddAsync(airport);
    }

    public async Task<Airport?> GetByIdAsync(int airportId)
    {
        return await dbContext.Airports.FindAsync(airportId);
    }

    public Task<Airport?> UpdateAsync(int airportId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Airport>> GetAllAsync()
    {
        return await dbContext.Airports.ToListAsync();
    }

    public async Task<Airport?> DeleteAsync(int airportId)
    {
        var airport = await dbContext.Airports.FindAsync(airportId);
        if (airport != null)
        {
            dbContext.Airports.Remove(airport);
            return airport;
        }

        return null;
    }
}