using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Facilities;
using AirportManagement.Domain.Facility;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Facilities.Commands.UpdateFacility;

public class UpdateFacilityCommandHandler(IFacilityRepository facilityRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateFacilityCommand, ErrorOr<Facility>>
{
    public async Task<ErrorOr<Facility>> Handle(UpdateFacilityCommand request, CancellationToken cancellationToken)
    {
        var newFacilityData = new Facility(request.Name, request.Type, request.Location);

        var facility = await facilityRepository.UpdateAsync(request.Id, newFacilityData);

        if (facility is null) return Error.NotFound($"Facility with id: {request.Id} was not found");

        await unitOfWork.CommitChangesAsync();

        return facility;
    }
}