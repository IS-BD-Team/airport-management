// src/AirportManagement.Infrastructure/Services/Persistence/RepairServiceRepository.cs

using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using AirportManagement.Domain.RepairServices;
using AirportManagement.Domain.Services;
using AirportManagement.Infrastructure.Common.Persistence;
using ErrorOr;

namespace AirportManagement.Infrastructure.Services.Persistence;

public class RepairServiceRepository(AirportManagementDbContext dbContext) : IRepairServiceRepository
{
    public async Task<Success> AddAsync(RepairService service)
    {
        await dbContext.AddAsync(service);
        return new Success();
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
        return await dbContext.RepairServices.FindAsync(serviceId);
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

    public Task<IQueryable<RepairService>> GetAllAsync()
    {
        return Task.FromResult(dbContext.RepairServices.AsQueryable());
    }
}