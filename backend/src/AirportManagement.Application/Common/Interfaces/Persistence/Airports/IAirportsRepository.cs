using AirportManagement.Domain.Airports;
using ErrorOr;

namespace AirportManagement.Application.Common.Interfaces.Persistence.Airports;

public interface IAirportsRepository
{
    Task<Success> AddAirportAsync(Airport airport);
    Task<Success> DeleteAsync(int airportId);
    Task<Airport?> GetByIdAsync(int airportId);
    Task<Airport?> UpdateAsync(int airportId, Airport airport);
    Task<IQueryable<Airport>> GetAllAsync();
}