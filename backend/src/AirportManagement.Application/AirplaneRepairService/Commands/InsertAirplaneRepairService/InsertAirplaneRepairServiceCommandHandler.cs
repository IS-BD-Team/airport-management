using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.AirplaneRepairService.Commands.InsertAirplaneRepairService;

public class InsertAirplaneRepairServiceCommandHandler(
    IAirplaneRepairServiceRepository repository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<InsertAirplaneRepairServiceCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(InsertAirplaneRepairServiceCommand request,
        CancellationToken cancellationToken)
    {
        await repository.InsertAirplaneRepairServiceAsync(request.FatherServiceId, request.ChildServiceId);
        await unitOfWork.CommitChangesAsync();
        return new Success();
    }
}