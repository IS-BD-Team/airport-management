using AirportManagement.Application.Common.Interfaces.Persistence.Airports;
using AirportManagement.Domain.Airports;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airports.Queries;

public class GetAirportsQueryHandler(IAirportsRepository airportsRepository)
    : IRequestHandler<GetAirportsQuery, ErrorOr<IEnumerable<Airport>>>
{
    public async Task<ErrorOr<IEnumerable<Airport>>> Handle(GetAirportsQuery request,
        CancellationToken cancellationToken)
    {
        var airports = await airportsRepository.GetAllAsync();

        var enumerable = airports.ToList();

        var list = enumerable.ToList();
        return list;
    }
}