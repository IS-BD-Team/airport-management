using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Airports;
using AirportManagement.Domain.Airports;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airports.Commands.DeleteAirport;

public class DeleteAirportCommandHandler(IAirportsRepository airportsRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteAirportCommand, ErrorOr<Airport>>
{
    public async Task<ErrorOr<Airport>> Handle(DeleteAirportCommand request, CancellationToken cancellationToken)
    {
        var airport = await airportsRepository.DeleteAsync(request.AirportId);
        await unitOfWork.CommitChangesAsync();

        return airport is null
            ? Error.NotFound($"Airport  with id:  {request.AirportId} was not found.")
            : airport;
    }
}