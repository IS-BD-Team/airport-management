using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Queries.GetService;

public class GetServiceQueryHandler(IServiceRepository serviceRepository)
    : IRequestHandler<GetServiceQuery, ErrorOr<Service>>
{
    public async Task<ErrorOr<Service>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
    {
        var service = await serviceRepository.GetByIdAsync(request.ServiceId);

        return service is null
            ? Error.NotFound($"Service with id: {request.ServiceId} was not found.")
            : service;
    }
}