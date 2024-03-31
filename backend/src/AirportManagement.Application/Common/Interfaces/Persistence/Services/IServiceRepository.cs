using AirportManagement.Domain.Services;
using ErrorOr;

namespace AirportManagement.Application.Common.Interfaces.Persistence.Services;

public interface IServiceRepository
{
    Task<Success> AddAsync(Service service);
    Task<Success> DeleteAsync(int serviceId);
    Task<Service?> GetByIdAsync(int serviceId);
    Task<Service?> UpdateAsync(int serviceId, Service newServiceData);
    Task<IQueryable<Service>> GetAllAsync();
}