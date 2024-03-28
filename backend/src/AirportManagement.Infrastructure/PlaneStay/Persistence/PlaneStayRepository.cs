using AirportManagement.Application.Common.Interfaces.Persistence.PlaneStay;
using AirportManagement.Infrastructure.Common.Persistence;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

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
        var planeStay = await dbContext.PlaneStays
            .Include(stay => stay.Airplane)
            .Include(stay => stay.Airport)
            .FirstOrDefaultAsync(stay => stay.Id == planeStayId);

        return planeStay;
    }

    public async Task<Domain.PlaneStay.PlaneStay?> UpdateAsync(int planeStayId, Domain.PlaneStay.PlaneStay planeStay)
    {
        var existingPlaneStay = await GetByIdAsync(planeStayId);

        if (existingPlaneStay is null) throw new Exception("Plane stay not found.");

        existingPlaneStay.AirplaneId = planeStay.AirplaneId;
        existingPlaneStay.AirportId = planeStay.AirportId;
        existingPlaneStay.ArrivalDate = planeStay.ArrivalDate;
        existingPlaneStay.DepartureDate = planeStay.DepartureDate;
        dbContext.Update(existingPlaneStay);

        return existingPlaneStay;
    }

    public async Task<IEnumerable<Domain.PlaneStay.PlaneStay>> GetAllAsync()
    {
        return await dbContext.PlaneStays
            .Include(stay => stay.Airplane)
            .Include(stay => stay.Airport)
            .ToListAsync();
    }
}