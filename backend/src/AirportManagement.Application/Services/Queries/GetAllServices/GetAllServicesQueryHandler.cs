using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Queries.GetAllServices;

public class GetServicesQueryHandler(IServiceRepository serviceRepository)
    : IRequestHandler<GetAllServicesQuery, ErrorOr<IQueryable<Service>>>
{
    public async Task<ErrorOr<IQueryable<Service>>> Handle(GetAllServicesQuery request,
        CancellationToken cancellationToken)
    {
        var services = await serviceRepository.GetAllAsync();

        return services.ToErrorOr();
    }
}