using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Airplanes;
using AirportManagement.Domain.Airplane;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airplanes.Commands.CreateAirplane;

public class CreateAirplaneCommandHandler(IAirplaneRepository airplaneRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateAirplaneCommand, ErrorOr<Airplane>>
{
    public async Task<ErrorOr<Airplane>> Handle(CreateAirplaneCommand request, CancellationToken cancellationToken)
    {
        var airplane = new Airplane(
            request.Classification,
            request.ClientId,
            request.MaxLoad,
            request.ArriveDate,
            request.DepartureDate
        );

        await airplaneRepository.AddAAsync(airplane);
        await unitOfWork.CommitChangesAsync();

        return airplane;
    }
}