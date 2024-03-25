using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Facilities;
using AirportManagement.Domain.Facility;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Facilities.Commands.DeleteFacility;

public class DeleteFacilityCommandHandler(IFacilityRepository facilityRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteFacilityCommand, ErrorOr<Facility>>
{
    public async Task<ErrorOr<Facility>> Handle(DeleteFacilityCommand request, CancellationToken cancellationToken)
    {
        var facility = await facilityRepository.DeleteAsync(request.FacilityId);
        await unitOfWork.CommitChangesAsync();

        return facility is null
            ? Error.NotFound($"Facility with id: {request.FacilityId} was not found.")
            : facility;
    }
}