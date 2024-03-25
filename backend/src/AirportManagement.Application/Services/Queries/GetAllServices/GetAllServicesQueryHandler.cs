using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Queries.GetAllServices;

public class GetServicesQueryHandler(IServiceRepository serviceRepository)
    : IRequestHandler<GetAllServicesQuery, ErrorOr<IEnumerable<Service>>>
{
    public async Task<ErrorOr<IEnumerable<Service>>> Handle(GetAllServicesQuery request,
        CancellationToken cancellationToken)
    {
        var services = await serviceRepository.GetAllAsync();

        return services.ToList();
    }
}