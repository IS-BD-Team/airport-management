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
        var newAirplane = new Airplane(
            request.Classification,
            request.PlanePlate,
            request.ClientId,
            request.MaxLoad,
            request.PassengersCapacity,
            request.CrewMembers);


        var airplane = await airplaneRepository.UpdateAsync(request.Id, newAirplane);

        if (airplane == null) return Error.NotFound($"Airplane with ID {request.Id} not found.");

        await unitOfWork.CommitChangesAsync();

        return airplane;
    }
}