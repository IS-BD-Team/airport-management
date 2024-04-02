using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.AirplaneRepairService.Queries.GetAllAirplaneRepairServices;

public class GetAllAirplaneRepairServicesQueryHandler(IAirplaneRepairServiceRepository repository)
    : IRequestHandler<GetAllAirplaneRepairServicesQuery,
        ErrorOr<IQueryable<Domain.AirplaneRepairService.AirplaneRepairService>>>
{
    public async Task<ErrorOr<IQueryable<Domain.AirplaneRepairService.AirplaneRepairService>>> Handle(
        GetAllAirplaneRepairServicesQuery request,
        CancellationToken cancellationToken)
    {
        var services = await repository.GetAllAsync();

        //remove airplaneRepairServices from each service
        foreach (var service in services) service.AirplaneRepairServices = null;

        return services.ToErrorOr();
    }
}