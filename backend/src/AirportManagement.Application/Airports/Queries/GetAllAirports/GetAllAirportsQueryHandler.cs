using AirportManagement.Application.Common.Interfaces.Persistence.Airports;
using AirportManagement.Domain.Airports;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airports.Queries.GetAllAirports;

public class GetAllAirportsQueryHandler(IAirportsRepository airportsRepository)
    : IRequestHandler<GetAllAirportsQuery, ErrorOr<IQueryable<Airport>>>
{
    public async Task<ErrorOr<IQueryable<Airport>>> Handle(GetAllAirportsQuery request,
        CancellationToken cancellationToken)
    {
        var airports = await airportsRepository.GetAllAsync();

        return airports.ToErrorOr();
    }
}