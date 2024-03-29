using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.AirplaneRepairService.Queries.GetAllAirplaneRepairServices;

public class GetAllAirplaneRepairServicesQueryHandler(IAirplaneRepairServiceRepository repository)
    : IRequestHandler<GetAllAirplaneRepairServicesQuery,
        ErrorOr<IEnumerable<Domain.Services.AirplaneRepairService.AirplaneRepairService>>>
{
    public async Task<ErrorOr<IEnumerable<Domain.Services.AirplaneRepairService.AirplaneRepairService>>> Handle(
        GetAllAirplaneRepairServicesQuery request,
        CancellationToken cancellationToken)
    {
        var services = await repository.GetAllAsync();
        return services.ToList();
    }
}