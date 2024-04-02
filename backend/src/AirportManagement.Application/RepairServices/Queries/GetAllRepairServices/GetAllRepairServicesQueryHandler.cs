using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using AirportManagement.Domain.RepairServices;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.RepairServices.Queries.GetAllRepairServices;

public class GetAllRepairServicesQueryHandler(IRepairServiceRepository repairServiceRepository)
    : IRequestHandler<GetAllRepairServicesQuery, ErrorOr<IQueryable<RepairService>>>
{
    public async Task<ErrorOr<IQueryable<RepairService>>> Handle(GetAllRepairServicesQuery request,
        CancellationToken cancellationToken)
    {
        var repairServices = await repairServiceRepository.GetAllAsync();
        return repairServices.ToErrorOr();
    }
}