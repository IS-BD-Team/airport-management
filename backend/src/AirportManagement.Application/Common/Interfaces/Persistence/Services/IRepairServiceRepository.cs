using AirportManagement.Domain.RepairServices;
using ErrorOr;

namespace AirportManagement.Application.Common.Interfaces.Persistence.Services;

public interface IRepairServiceRepository
{
    Task<Success> AddAsync(RepairService repairService);
    Task<Success> DeleteAsync(int id);
    Task<RepairService?> GetByIdAsync(int id);
    Task<RepairService?> UpdateAsync(int serviceId, RepairService repairService);
    Task<IQueryable<RepairService>> GetAllAsync();
}