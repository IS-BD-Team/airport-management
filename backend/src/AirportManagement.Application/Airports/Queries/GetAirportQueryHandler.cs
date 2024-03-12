using AirportManagement.Application.Common.Interfaces.Persistence.Airports;
using AirportManagement.Domain.Airports;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airports.Queries;

public class GetAirportQueryHandler(IAirportsRepository airportsRepository)
    : IRequestHandler<GetAirportQuery, ErrorOr<Airport>>
{
    public async Task<ErrorOr<Airport>> Handle(GetAirportQuery request, CancellationToken cancellationToken)
    {
        var airport = await airportsRepository.GetByIdAsync(request.AirportId);

        return airport is null
            ? Error.NotFound($"Airport  with id:  {request.AirportId} was not found.")
            : airport;
    }
}