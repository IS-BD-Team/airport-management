using AirportManagement.Application.Common.Interfaces.Persistence.Airplanes;
using AirportManagement.Domain.Airplane;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airplanes.Queries.GetAllAirplanes;

public class GetAllAirplanesQueryHandler(IAirplaneRepository airplaneRepository)
    : IRequestHandler<GetAllAirplanesQuery, ErrorOr<IQueryable<Airplane>>>
{
    public async Task<ErrorOr<IQueryable<Airplane>>> Handle(GetAllAirplanesQuery request,
        CancellationToken cancellationToken)
    {
        var airplanes = await airplaneRepository.GetAllAsync();
        return airplanes.ToErrorOr();
    }
}