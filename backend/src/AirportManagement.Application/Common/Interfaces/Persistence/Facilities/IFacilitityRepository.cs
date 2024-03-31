using AirportManagement.Domain.Facility;
using ErrorOr;

namespace AirportManagement.Application.Common.Interfaces.Persistence.Facilities;

public interface IFacilityRepository
{
    Task AddAsync(Facility facility);
    Task<Success> DeleteAsync(int facilityId);
    Task<Facility?> GetByIdAsync(int facilityId);
    Task<Facility?> UpdateAsync(int facilityId, Facility newFacilityData);
    Task<IQueryable<Facility>> GetAllAsync();
}