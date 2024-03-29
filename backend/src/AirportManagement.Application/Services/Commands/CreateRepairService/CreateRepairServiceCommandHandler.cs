using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Commands.CreateRepairService;

public class CreateRepairServiceCommandHandler(IRepairServiceRepository repairServiceRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateRepairServiceCommand, ErrorOr<RepairService>>
{
    public async Task<ErrorOr<RepairService>> Handle(CreateRepairServiceCommand request,
        CancellationToken cancellationToken)
    {
        var repairService = new RepairService(
            request.Description,
            request.FacilityId,
            request.Price,
            request.Type
        );

        await repairServiceRepository.AddAsync(repairService);
        await unitOfWork.CommitChangesAsync();

        return (await repairServiceRepository.GetByIdAsync(repairService.Id))!;
    }
}