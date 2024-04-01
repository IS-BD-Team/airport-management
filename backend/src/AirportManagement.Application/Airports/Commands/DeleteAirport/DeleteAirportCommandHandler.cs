using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Airports;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airports.Commands.DeleteAirport;

public class DeleteAirportCommandHandler(IAirportsRepository airportsRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteAirportCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteAirportCommand request, CancellationToken cancellationToken)
    {
        var result = await airportsRepository.DeleteAsync(request.AirportId);
        await unitOfWork.CommitChangesAsync();

        return new Success();
    }
}