using AirportManagement.Application.Common.Interfaces.Persistence.Airplanes;
using AirportManagement.Domain.Airplane;
using AirportManagement.Infrastructure.Common.Persistence;
using ErrorOr;

namespace AirportManagement.Infrastructure.Airplanes.Persistence;

public class AirplaneRepository(AirportManagementDbContext dbContext) : IAirplaneRepository
{
    public async Task<Success> AddAsync(Airplane airplane)
    {
        await dbContext.Airplanes.AddAsync(airplane);
        return new Success();
    }

    public async Task<Airplane?> UpdateAsync(int airplaneId, Airplane airplane)
    {
        var existingAirplane = await GetByIdAsync(airplaneId);

        if (existingAirplane is not null)
        {
            existingAirplane.Classification = airplane.Classification;
            existingAirplane.ClientId = airplane.ClientId;
            existingAirplane.MaxLoad = airplane.MaxLoad;
            existingAirplane.CrewMembers = airplane.CrewMembers;
            existingAirplane.HasReceivedMaintenance = airplane.HasReceivedMaintenance;
            dbContext.Update(existingAirplane);
        }

        return existingAirplane;
    }

    public Task<IQueryable<Airplane>> GetAllAsync()
    {
        return Task.FromResult(dbContext.Airplanes.AsQueryable());
    }

    public async Task<Success> DeleteAsync(int airplaneId)
    {
        var airplane = await GetByIdAsync(airplaneId);
        if (airplane is null) throw new Exception("Airplane not found");
        dbContext.Airplanes.Remove(airplane);

        return new Success();
    }

    public async Task<Airplane?> GetByIdAsync(int airplaneId)
    {
        return await dbContext.Airplanes.FindAsync(airplaneId);
    }
}