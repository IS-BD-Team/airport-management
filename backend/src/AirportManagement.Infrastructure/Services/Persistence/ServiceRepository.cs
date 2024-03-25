using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using AirportManagement.Domain.Services;
using AirportManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Infrastructure.Services.Persistence;

public class ServiceRepository(AirportManagementDbContext dbContext) : IServiceRepository
{
    public async Task AddAsync(Service service)
    {
        await dbContext.Services.AddAsync(service);
    }

    public async Task<Service?> DeleteAsync(int serviceId)
    {
        var service = await dbContext.Services.FindAsync(serviceId);
        if (service != null) dbContext.Services.Remove(service);

        return service;
    }

    public async Task<Service?> GetByIdAsync(int serviceId)
    {
        var query = dbContext.Services.AsQueryable();
        query = query.Include(service => service.Facility);
        return await query.FirstOrDefaultAsync(service => service.Id == serviceId);
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

    public async Task<IEnumerable<Service>> GetAllAsync()
    {
        return await dbContext.Services.ToListAsync();
    }
}