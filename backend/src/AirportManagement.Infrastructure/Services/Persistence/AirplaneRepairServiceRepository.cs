using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using AirportManagement.Domain.Services.AirplaneRepairService;
using AirportManagement.Infrastructure.Common.Persistence;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

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
        var service = await dbContext.AirplaneRepairServices
            .Include(repairService => repairService.RepairService)
            .Include(repairService => repairService.Plane)
            .FirstOrDefaultAsync(repairService => repairService.Id == serviceId);

        return service;
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

    public async Task<IEnumerable<AirplaneRepairService>> GetAllAsync()
    {
        return await dbContext.AirplaneRepairServices
            .Include(repairService => repairService.RepairService)
            .Include(repairService => repairService.Plane)
            .ToListAsync();
    }
}