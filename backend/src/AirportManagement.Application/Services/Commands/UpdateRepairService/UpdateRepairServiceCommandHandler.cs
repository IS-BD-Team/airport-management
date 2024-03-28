using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Commands.UpdateRepairService;

public class UpdateRepairServiceCommandHandler(IRepairServiceRepository repairServiceRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateRepairServiceCommand, ErrorOr<RepairService>>
{
    public async Task<ErrorOr<RepairService>> Handle(UpdateRepairServiceCommand request,
        CancellationToken cancellationToken)
    {
        var newService = new RepairService(request.Description, request.FacilityId, request.Price, request.Type);
        var repairService = await repairServiceRepository.UpdateAsync(request.ServiceId, newService);
        if (repairService is null) return Error.NotFound($"Repair service with id: {request.ServiceId} was not found");

        await unitOfWork.CommitChangesAsync();
        return (await repairServiceRepository.GetByIdAsync(repairService.Id))!;
    }
}