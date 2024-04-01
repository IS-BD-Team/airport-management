using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.AirplaneRepairService.Queries.GetAirplaneRepairService;

public class GetAirplaneRepairServiceQueryHandler(IAirplaneRepairServiceRepository repository)
    : IRequestHandler<GetAirplaneRepairServiceQuery,
        ErrorOr<Domain.AirplaneRepairService.AirplaneRepairService>>
{
    public async Task<ErrorOr<Domain.AirplaneRepairService.AirplaneRepairService>> Handle(
        GetAirplaneRepairServiceQuery request, CancellationToken cancellationToken)
    {
        var service = await repository.GetByIdAsync(request.ServiceId);

        return service is null ? Error.NotFound("Airplane repair service not found") : service;
    }
}