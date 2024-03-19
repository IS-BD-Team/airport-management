using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Airports;
using AirportManagement.Domain.Airports;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airports.Commands.UpdateAirport;

public class UpdateAirportCommandHandler(IAirportsRepository airportsRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateAirportCommand, ErrorOr<Airport>>
{
    public async Task<ErrorOr<Airport>> Handle(UpdateAirportCommand request, CancellationToken cancellationToken)
    {
        var newAirportData = new Airport(request.Name, request.Address);

        var airport = await airportsRepository.UpdateAsync(request.Id, newAirportData);

        if (airport is null) return Error.NotFound($"Airport with id: {request.Id} was not found");

        await unitOfWork.CommitChangesAsync();

        return newAirportData;
    }
}