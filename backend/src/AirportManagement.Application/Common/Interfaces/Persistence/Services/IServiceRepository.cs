using AirportManagement.Domain.Services;

namespace AirportManagement.Application.Common.Interfaces.Persistence.Services;

public interface IServiceRepository
{
    Task AddAsync(Service service);
    Task<Service?> DeleteAsync(int serviceId);
    Task<Service?> GetByIdAsync(int serviceId);
    Task<Service?> UpdateAsync(int serviceId, Service newServiceData);
    Task<IEnumerable<Service>> GetAllAsync();
}