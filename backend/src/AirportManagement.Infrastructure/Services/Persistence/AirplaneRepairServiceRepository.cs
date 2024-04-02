using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using AirportManagement.Domain.AirplaneRepairService;
using AirportManagement.Infrastructure.Common.Persistence;
using ErrorOr;

namespace AirportManagement.Infrastructure.Services.Persistence;

public class AirplaneRepairServiceRepository(AirportManagementDbContext dbContext) : IAirplaneRepairServiceRepository
{
    public async Task<Success> AddAsync(AirplaneRepairService service)
    {
        await dbContext.AirplaneRepairServices.AddAsync(service);
        return new Success();
    }

    public async Task<Success> DeleteAsync(int serviceId)
    {
        var service = await dbContext.AirplaneRepairServices.FindAsync(serviceId);
        if (service is null) throw new Exception("Service not found.");
        dbContext.AirplaneRepairServices.Remove(service);
        return new Success();
    }

    public async Task<AirplaneRepairService?> GetByIdAsync(int serviceId)
    {
        return await dbContext.AirplaneRepairServices.FindAsync(serviceId);
    }

    public async Task<AirplaneRepairService?> UpdateAsync(int serviceId, AirplaneRepairService newServiceData)
    {
        var existingService = await GetByIdAsync(serviceId);

        if (existingService is null) throw new Exception("Service not found.");

        existingService.RepairServiceId = newServiceData.RepairServiceId;
        existingService.AirPlaneId = newServiceData.AirPlaneId;
        existingService.StartDate = newServiceData.StartDate;
        existingService.EndDate = newServiceData.EndDate;
        dbContext.AirplaneRepairServices.Update(existingService);

        return existingService;
    }

    public Task<IQueryable<AirplaneRepairService>> GetAllAsync()
    {
        return Task.FromResult(dbContext.AirplaneRepairServices.AsQueryable());
    }

    public async Task<Success> InsertAirplaneRepairServiceAsync(int fatherId, int childId)
    {
        var fatherAirplaneRepairService = await GetByIdAsync(fatherId);
        var childAirplaneRepairService = await GetByIdAsync(childId);

        if (fatherAirplaneRepairService is null) throw new Exception("Service not found.");
        if (childAirplaneRepairService is null) throw new Exception("Service not found.");

        fatherAirplaneRepairService.AirplaneRepairServices.Add(childAirplaneRepairService);
        return new Success();
    }
}