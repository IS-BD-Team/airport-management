using AirportManagement.Domain.Facility;

namespace AirportManagement.Application.Common.Interfaces.Persistence.Facilities;

public interface IFacilityRepository
{
    Task AddAsync(Facility facility);
    Task<Facility?> DeleteAsync(int facilityId);
    Task<Facility?> GetByIdAsync(int facilityId);
    Task<Facility?> UpdateAsync(int facilityId, Facility newFacilityData);
    Task<IEnumerable<Facility>> GetAllAsync();
}