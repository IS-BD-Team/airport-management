using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Facilities;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Facilities.Commands.DeleteFacility;

public class DeleteFacilityCommandHandler(IFacilityRepository facilityRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteFacilityCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteFacilityCommand request, CancellationToken cancellationToken)
    {
        await facilityRepository.DeleteAsync(request.FacilityId);
        await unitOfWork.CommitChangesAsync();
        return new Success();
    }
}