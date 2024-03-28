using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.PlaneStay;
using AirportManagement.Domain.PlaneStay;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.PlaneStays.Commands.CreatePlaneStay;

public class CreatePlaneStayCommandHandler(IPlaneStayRepository planeStayRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreatePlaneStayCommand, ErrorOr<PlaneStay>>
{
    public async Task<ErrorOr<PlaneStay>> Handle(CreatePlaneStayCommand request, CancellationToken cancellationToken)
    {
        var planeStay = new PlaneStay(
            request.PlaneId,
            request.AirportId,
            request.ArrivalDate,
            request.DepartureDate
        );

        await planeStayRepository.AddAsync(planeStay);
        await unitOfWork.CommitChangesAsync();

        return (await planeStayRepository.GetByIdAsync(planeStay.Id))!;
    }
}