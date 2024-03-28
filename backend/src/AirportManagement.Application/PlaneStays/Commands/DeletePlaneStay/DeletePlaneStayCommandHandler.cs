using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.PlaneStay;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.PlaneStays.Commands.DeletePlaneStay;

public class DeletePlaneStayCommandHandler(IPlaneStayRepository planeStayRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeletePlaneStayCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeletePlaneStayCommand request, CancellationToken cancellationToken)
    {
        await planeStayRepository.DeleteAsync(request.StayId);
        await unitOfWork.CommitChangesAsync();
        return new Success();
    }
}