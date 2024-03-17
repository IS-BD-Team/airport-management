using AirportManagement.Domain.Airports;

namespace AirportManagement.Application.Common.Interfaces.Persistence.Airports;

public interface IAirportsRepository
{
    Task AddAirportAsync(Airport airport);
    Task<Airport?> DeleteAsync(int airportId);
    Task<Airport?> GetByIdAsync(int airportId);
    Task<Airport?> UpdateAsync(int airportId);
    Task<IEnumerable<Airport>> GetAllAsync();
}