using AirportManagement.Application.Common.Interfaces.Persistence.Airports;
using AirportManagement.Domain.Airports;
using AirportManagement.Infrastructure.Common.Persistence;
using ErrorOr;

namespace AirportManagement.Infrastructure.Airports.Persistence;

public class AirportRepository(AirportManagementDbContext dbContext) : IAirportsRepository
{
    public async Task<Success> AddAirportAsync(Airport airport)
    {
        await dbContext.Airports.AddAsync(airport);
        return new Success();
    }

    public async Task<Airport?> GetByIdAsync(int airportId)
    {
        return await dbContext.Airports.FindAsync(airportId);
    }

    public async Task<Success> DeleteAsync(int airportId)
    {
        var airport = await dbContext.Airports.FindAsync(airportId);
        if (airport is null) throw new Exception("Airport not found");
        dbContext.Airports.Remove(airport);

        return new Success();
    }

    public async Task<Airport?> UpdateAsync(int airportId, Airport airport)
    {
        var existingAirport = await dbContext.Airports.FindAsync(airportId);
        if (existingAirport != null)
        {
            existingAirport.Name = airport.Name;
            existingAirport.Address = airport.Address;
            existingAirport.GeographicLocation = airport.GeographicLocation;
            return existingAirport;
        }

        return null;
    }

    public Task<IQueryable<Airport>> GetAllAsync()
    {
        return Task.FromResult(dbContext.Airports.AsQueryable());
    }
}