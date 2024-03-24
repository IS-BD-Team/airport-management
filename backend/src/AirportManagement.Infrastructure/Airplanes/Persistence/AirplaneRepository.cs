using AirportManagement.Application.Common.Interfaces.Persistence.Airplanes;
using AirportManagement.Domain.Airplane;
using AirportManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Infrastructure.Airplanes.Persistence;

public class AirplaneRepository(AirportManagementDbContext dbContext) : IAirplaneRepository
{
    public async Task AddAAsync(Airplane airplane)
    {
        await dbContext.Airplanes.AddAsync(airplane);
    }

    public async Task<Airplane?> GetByIdAsync(int airplaneId)
    {
        return await dbContext.Airplanes.FindAsync(airplaneId);
    }

    public async Task<Airplane?> UpdateAsync(int airplaneId, Airplane airplane)
    {
        var existingAirplane = await GetByIdAsync(airplaneId);

        if (existingAirplane is not null)
        {
            existingAirplane.Classification = airplane.Classification;
            existingAirplane.ClientId = airplane.ClientId;
            existingAirplane.MaxLoad = airplane.MaxLoad;
            existingAirplane.ArriveDate = airplane.ArriveDate;
            existingAirplane.DepartureDate = airplane.DepartureDate;
            existingAirplane.HasReceivedMaintenance = airplane.HasReceivedMaintenance;

            dbContext.Update(existingAirplane);
        }

        return existingAirplane;
    }

    public async Task<IEnumerable<Airplane>> GetAllAsync()
    {
        return await dbContext.Airplanes.ToListAsync();
    }

    public async Task<Airplane?> DeleteAsync(int airplaneId)
    {
        var airplane = await GetByIdAsync(airplaneId);
        if (airplane is not null) dbContext.Airplanes.Remove(airplane);

        return airplane;
    }
}