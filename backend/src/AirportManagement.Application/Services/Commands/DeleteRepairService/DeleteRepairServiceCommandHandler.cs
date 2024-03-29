using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Commands.DeleteRepairService;

public class DeleteRepairServiceCommandHandler(IRepairServiceRepository repairServiceRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteRepairServiceCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteRepairServiceCommand request, CancellationToken cancellationToken)
    {
        await repairServiceRepository.DeleteAsync(request.ServiceId);
        await unitOfWork.CommitChangesAsync();
        return new Success();
    }
}