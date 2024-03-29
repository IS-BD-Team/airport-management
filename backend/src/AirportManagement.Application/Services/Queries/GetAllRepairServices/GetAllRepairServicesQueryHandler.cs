using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Queries.GetAllRepairServices;

public class GetAllRepairServicesQueryHandler(IRepairServiceRepository repairServiceRepository)
    : IRequestHandler<GetAllRepairServicesQuery, ErrorOr<IEnumerable<RepairService>>>
{
    public async Task<ErrorOr<IEnumerable<RepairService>>> Handle(GetAllRepairServicesQuery request,
        CancellationToken cancellationToken)
    {
        var repairServices = await repairServiceRepository.GetAllAsync();
        return repairServices.ToList();
    }
}