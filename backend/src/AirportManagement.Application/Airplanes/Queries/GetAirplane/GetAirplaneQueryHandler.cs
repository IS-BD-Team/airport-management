using AirportManagement.Application.Common.Interfaces.Persistence.Airplanes;
using AirportManagement.Domain.Airplane;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airplanes.Queries.GetAirplane;

public class GetAirplaneQueryHandler(IAirplaneRepository airplaneRepository)
    : IRequestHandler<GetAirplaneQuery, ErrorOr<Airplane>>
{
    public async Task<ErrorOr<Airplane>> Handle(GetAirplaneQuery request, CancellationToken cancellationToken)
    {
        var airplane = await airplaneRepository.GetByIdAsync(request.Id);

        if (airplane == null) return Error.NotFound($"Airplane with ID {request.Id} not found.");

        return airplane;
    }
}