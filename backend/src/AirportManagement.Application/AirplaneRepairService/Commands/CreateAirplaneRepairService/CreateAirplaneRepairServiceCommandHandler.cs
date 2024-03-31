using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.AirplaneRepairService.Commands.CreateAirplaneRepairService;

public class CreateAirplaneRepairServiceCommandHandler(
    IAirplaneRepairServiceRepository repository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateAirplaneRepairServiceCommand,
        ErrorOr<Domain.AirplaneRepairService.AirplaneRepairService>>
{
    public async Task<ErrorOr<Domain.AirplaneRepairService.AirplaneRepairService>> Handle(
        CreateAirplaneRepairServiceCommand request,
        CancellationToken cancellationToken)
    {
        var service = new Domain.AirplaneRepairService.AirplaneRepairService(request.AirPlaneId,
            request.RepairServiceId,
            request.StartDate,
            request.EndDate);

        await repository.AddAsync(service);
        await unitOfWork.CommitChangesAsync();

        return (await repository.GetByIdAsync(service.Id))!;
    }
}