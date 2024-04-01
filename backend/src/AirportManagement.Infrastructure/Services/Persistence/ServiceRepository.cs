using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using AirportManagement.Domain.Services;
using AirportManagement.Infrastructure.Common.Persistence;
using ErrorOr;

namespace AirportManagement.Infrastructure.Services.Persistence;

public class ServiceRepository(AirportManagementDbContext dbContext) : IServiceRepository
{
    public async Task<Success> AddAsync(Service service)
    {
        await dbContext.Services.AddAsync(service);
        return new Success();
    }

    public async Task<Success> DeleteAsync(int serviceId)
    {
        var service = await dbContext.Services.FindAsync(serviceId);
        if (service is null) throw new Exception("Service not found");
        dbContext.Services.Remove(service);

        return new Success();
    }

    public async Task<Service?> GetByIdAsync(int serviceId)
    {
        return await dbContext.Services.FindAsync(serviceId);
    }

    public async Task<Service?> UpdateAsync(int serviceId, Service newServiceData)
    {
        var existingService = await dbContext.Services.FindAsync(serviceId);

        if (existingService != null)
        {
            existingService.Description = newServiceData.Description;
            existingService.FacilityId = newServiceData.FacilityId;
            existingService.Price = newServiceData.Price;

            dbContext.Update(existingService);
        }

        return existingService;
    }

    public Task<IQueryable<Service>> GetAllAsync()
    {
        return Task.FromResult(dbContext.Services.AsQueryable());
    }
}