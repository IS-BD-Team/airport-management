using AirportManagement.Domain.Airplane;

namespace AirportManagement.Application.Common.Interfaces.Persistence.Airplanes;

public interface IAirplaneRepository
{
    Task AddAsync(Airplane airplane);
    Task<Airplane?> DeleteAsync(int airplaneId);
    Task<Airplane?> GetByIdAsync(int airplaneId);
    Task<Airplane?> UpdateAsync(int airplaneId, Airplane airplane);
    Task<IEnumerable<Airplane>> GetAllAsync();
}