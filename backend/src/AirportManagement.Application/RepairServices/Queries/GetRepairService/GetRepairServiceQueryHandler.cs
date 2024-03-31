using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using AirportManagement.Domain.RepairServices;
using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.RepairServices.Queries.GetRepairService;

public class GetRepairServiceQueryHandler(IRepairServiceRepository repairServiceRepository) :
    IRequestHandler<GetRepairServiceQuery, ErrorOr<RepairService>>
{
    public async Task<ErrorOr<RepairService>> Handle(GetRepairServiceQuery request, CancellationToken cancellationToken)
    {
        var repairService = await repairServiceRepository.GetByIdAsync(request.ServiceId);

        return repairService is null ? Error.NotFound("Repair service not found") : repairService;
    }
}