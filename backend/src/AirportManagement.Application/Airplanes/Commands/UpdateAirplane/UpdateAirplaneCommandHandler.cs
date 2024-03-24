using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Airplanes;
using AirportManagement.Domain.Airplane;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airplanes.Commands.UpdateAirplane;

public class UpdateAirplaneCommandHandler(IAirplaneRepository airplaneRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateAirplaneCommand, ErrorOr<Airplane>>
{
    public async Task<ErrorOr<Airplane>> Handle(UpdateAirplaneCommand request, CancellationToken cancellationToken)
    {
        var airplane = await airplaneRepository.GetByIdAsync(request.Id);

        if (airplane == null) return Error.NotFound($"Airplane with ID {request.Id} not found.");

        airplane.Classification = request.Classification;
        airplane.ClientId = request.ClientId;
        airplane.MaxLoad = request.MaxLoad;
        airplane.ArriveDate = request.ArriveDate;
        airplane.DepartureDate = request.DepartureDate;
        airplane.HasReceivedMaintenance = request.HasReceivedMaintenance;

        await unitOfWork.CommitChangesAsync();

        return airplane;
    }
}