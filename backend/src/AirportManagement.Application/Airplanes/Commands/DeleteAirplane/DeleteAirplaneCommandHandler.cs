using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Airplanes;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airplanes.Commands.DeleteAirplane;

public class DeleteAirplaneCommandHandler(IAirplaneRepository airplaneRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteAirplaneCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteAirplaneCommand request, CancellationToken cancellationToken)
    {
        var airplane = await airplaneRepository.DeleteAsync(request.Id);

        await unitOfWork.CommitChangesAsync();

        return airplane == null
            ? Error.NotFound($"Airplane with ID {request.Id} not found.")
            : Result.Success;
    }
}