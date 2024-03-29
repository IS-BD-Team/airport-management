using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.AirplaneRepairService.Commands.UpdateAirplaneRepairService;

public class UpdateAirplaneRepairServiceCommandHandler(
    IAirplaneRepairServiceRepository repository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateAirplaneRepairServiceCommand,
        ErrorOr<Domain.Services.AirplaneRepairService.AirplaneRepairService>>
{
    public async Task<ErrorOr<Domain.Services.AirplaneRepairService.AirplaneRepairService>> Handle(
        UpdateAirplaneRepairServiceCommand request,
        CancellationToken cancellationToken)
    {
        var newService = new Domain.Services.AirplaneRepairService.AirplaneRepairService(
            request.AirPlaneId,
            request.RepairServiceId, request.StartDate,
            request.EndDate);
        var service = await repository.UpdateAsync(request.ServiceId, newService);

        if (service is null)
            return Error.NotFound($"Airplane repair service with id: {request.ServiceId} was not found");

        await unitOfWork.CommitChangesAsync();
        return (await repository.GetByIdAsync(service.Id))!;
    }
}