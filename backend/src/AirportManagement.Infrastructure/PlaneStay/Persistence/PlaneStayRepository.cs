using AirportManagement.Application.Common.Interfaces.Persistence.PlaneStay;
using AirportManagement.Infrastructure.Common.Persistence;
using ErrorOr;

namespace AirportManagement.Infrastructure.PlaneStay.Persistence;

public class PlaneStayRepository(AirportManagementDbContext dbContext) : IPlaneStayRepository
{
    public async Task<Success> AddAsync(Domain.PlaneStay.PlaneStay planeStay)
    {
        await dbContext.AddAsync(planeStay);
        return new Success();
    }

    public async Task<Success> DeleteAsync(int planeStayId)
    {
        var planeStay = await dbContext.PlaneStays.FindAsync(planeStayId);
        if (planeStay is null) throw new Exception("Plane stay not found.");
        dbContext.Remove(planeStay);
        return new Success();
    }

    public async Task<Domain.PlaneStay.PlaneStay?> GetByIdAsync(int planeStayId)
    {
        return await dbContext.PlaneStays.FindAsync(planeStayId);
    }

    public async Task<Domain.PlaneStay.PlaneStay?> UpdateAsync(int planeStayId, Domain.PlaneStay.PlaneStay planeStay)
    {
        var existingPlaneStay = await GetByIdAsync(planeStayId);

        if (existingPlaneStay is null) throw new Exception("Plane stay not found.");

        existingPlaneStay.AirplaneId = planeStay.AirplaneId;
        existingPlaneStay.AirportId = planeStay.AirportId;
        existingPlaneStay.Rating = planeStay.Rating;
        existingPlaneStay.ArrivalDate = planeStay.ArrivalDate;
        existingPlaneStay.DepartureDate = planeStay.DepartureDate;
        dbContext.Update(existingPlaneStay);

        return existingPlaneStay;
    }

    public Task<IQueryable<Domain.PlaneStay.PlaneStay>> GetAllAsync()
    {
        return Task.FromResult(dbContext.PlaneStays.AsQueryable());
    }
}