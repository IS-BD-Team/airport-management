using AirportManagement.Domain.Services.AirplaneRepairService;
using ErrorOr;

namespace AirportManagement.Application.Common.Interfaces.Persistence.Services;

public interface IAirplaneRepairServiceRepository
{
    Task<Success> AddAsync(AirplaneRepairService service);
    Task<Success> DeleteAsync(int serviceId);
    Task<AirplaneRepairService?> GetByIdAsync(int serviceId);
    Task<AirplaneRepairService?> UpdateAsync(int serviceId, AirplaneRepairService newServiceData);
    Task<IEnumerable<AirplaneRepairService>> GetAllAsync();
}