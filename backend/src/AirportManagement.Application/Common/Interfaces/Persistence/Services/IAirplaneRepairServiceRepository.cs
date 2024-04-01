using ErrorOr;

namespace AirportManagement.Application.Common.Interfaces.Persistence.Services;

public interface IAirplaneRepairServiceRepository
{
    Task<Success> AddAsync(Domain.AirplaneRepairService.AirplaneRepairService service);
    Task<Success> DeleteAsync(int serviceId);
    Task<Domain.AirplaneRepairService.AirplaneRepairService?> GetByIdAsync(int serviceId);

    Task<Domain.AirplaneRepairService.AirplaneRepairService?> UpdateAsync(int serviceId,
        Domain.AirplaneRepairService.AirplaneRepairService newServiceData);

    Task<IQueryable<Domain.AirplaneRepairService.AirplaneRepairService>> GetAllAsync();
}