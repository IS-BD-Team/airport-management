using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.AirplaneRepairService.Commands.DeleteAirplaneRepairService;

public class
    DeleteAirplaneRepairServiceCommandHandler(
        IAirplaneRepairServiceRepository repository,
        IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteAirplaneRepairServiceCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteAirplaneRepairServiceCommand request,
        CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.ServiceId);
        await unitOfWork.CommitChangesAsync();

        return new Success();
    }
}