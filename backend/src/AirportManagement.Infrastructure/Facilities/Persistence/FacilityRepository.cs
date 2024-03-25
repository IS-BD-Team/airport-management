using AirportManagement.Application.Common.Interfaces.Persistence.Facilities;
using AirportManagement.Domain.Facility;
using AirportManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Infrastructure.Facilities.Persistence;

public class FacilityRepository(AirportManagementDbContext dbContext) : IFacilityRepository
{
    public async Task AddAsync(Facility facility)
    {
        await dbContext.Facilities.AddAsync(facility);
    }

    public async Task<Facility?> DeleteAsync(int facilityId)
    {
        var facility = await dbContext.Facilities.FindAsync(facilityId);
        if (facility != null) dbContext.Facilities.Remove(facility);

        return facility;
    }

    public async Task<Facility?> GetByIdAsync(int facilityId)
    {
        return await dbContext.Facilities.FindAsync(facilityId);
    }

    public async Task<Facility?> UpdateAsync(int facilityId, Facility newFacilityData)
    {
        var existingFacility = await dbContext.Facilities.FindAsync(facilityId);

        if (existingFacility != null)
        {
            existingFacility.Name = newFacilityData.Name;
            existingFacility.Type = newFacilityData.Type;
            existingFacility.Location = newFacilityData.Location;

            dbContext.Update(existingFacility);
        }

        return existingFacility;
    }

    public async Task<IEnumerable<Facility>> GetAllAsync()
    {
        return await dbContext.Facilities.ToListAsync();
    }
}