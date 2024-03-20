using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Airports;
using AirportManagement.Domain.Airports;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airports.Commands.CreateAirport;

public class CreateAirportCommandHandler(IAirportsRepository airportsRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateAirportCommand, ErrorOr<Airport>>
{
    public async Task<ErrorOr<Airport>> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
    {
        var airport = new Airport(request.Name, request.Address, request.GeographicLocation);

        await airportsRepository.AddAirportAsync(airport);
        await unitOfWork.CommitChangesAsync();

        return airport;
    }
}