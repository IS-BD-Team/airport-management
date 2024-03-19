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

    /// <summary>
    /// </summary>
    /// <param name="airportId"></param>
    /// <param name="airport"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Airport?> UpdateAsync(int airportId, Airport airport)
    {
        var existingAirport = await dbContext.Airports.FindAsync(airportId);
        if (existingAirport != null)
        {
            existingAirport.Name = airport.Name;
            existingAirport.Address = airport.Address;
            await dbContext.SaveChangesAsync();
            return existingAirport;
        }

        return null;
    }
}