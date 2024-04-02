using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.PlaneStay;
using AirportManagement.Domain.PlaneStay;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.PlaneStays.Commands.UpdatePlaneStay;

public class UpdatePlaneStayCommandHandler(IPlaneStayRepository planeStayRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdatePlaneStayCommand, ErrorOr<PlaneStay>>
{
    public async Task<ErrorOr<PlaneStay>> Handle(UpdatePlaneStayCommand request, CancellationToken cancellationToken)
    {
        var newStay = new PlaneStay(request.PlaneId,
            request.AirportId,
            request.Rating,
            request.Start,
            request.End);

        var planeStay = await planeStayRepository.UpdateAsync(request.StayId, newStay);
        if (planeStay is null) return Error.NotFound($"Plane stay with id: {request.StayId} was not found");

        await unitOfWork.CommitChangesAsync();
        return (await planeStayRepository.GetByIdAsync(planeStay.Id))!;
    }
}