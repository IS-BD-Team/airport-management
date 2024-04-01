using AirportManagement.Domain.Airplane;
using ErrorOr;

namespace AirportManagement.Application.Common.Interfaces.Persistence.Airplanes;

public interface IAirplaneRepository
{
    Task<Success> AddAsync(Airplane airplane);
    Task<Success> DeleteAsync(int airplaneId);
    Task<Airplane?> GetByIdAsync(int airplaneId);
    Task<Airplane?> UpdateAsync(int airplaneId, Airplane airplane);
    Task<IQueryable<Airplane>> GetAllAsync();
}