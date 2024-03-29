// src/AirportManagement.Infrastructure/Services/Persistence/RepairServiceRepository.cs

using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using AirportManagement.Domain.Services;
using AirportManagement.Infrastructure.Common.Persistence;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Infrastructure.Services.Persistence;

public class RepairServiceRepository(AirportManagementDbContext dbContext) : IRepairServiceRepository
{
    public async Task AddAsync(RepairService service)
    {
        await dbContext.AddAsync(service);
    }

    public async Task<Success> DeleteAsync(int serviceId)
    {
        var service = await dbContext.Services.FindAsync(serviceId);
        if (service is null) throw new Exception("Service not found.");
        dbContext.Remove(service);
        return new Success();
    }

    public async Task<RepairService?> GetByIdAsync(int serviceId)
    {
        var service = await dbContext.RepairServices
            .Include(s => s.Facility)
            .FirstOrDefaultAsync(repairService => repairService.Id == serviceId);

        return service;
    }

    public async Task<RepairService?> UpdateAsync(int serviceId, RepairService service)
    {
        var existingService = await GetByIdAsync(serviceId);

        if (existingService is null) throw new Exception("Service not found.");

        existingService.Description = service.Description;
        existingService.FacilityId = service.FacilityId;
        existingService.Price = service.Price;
        dbContext.Update(existingService);

        return await GetByIdAsync(existingService.Id);
    }

    public async Task<IEnumerable<RepairService>> GetAllAsync()
    {
        return await dbContext.RepairServices.Include(service => service.Facility)
            .ToListAsync();
    }
}