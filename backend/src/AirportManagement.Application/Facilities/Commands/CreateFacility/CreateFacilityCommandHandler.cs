using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Facilities;
using AirportManagement.Domain.Facility;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Facilities.Commands.CreateFacility;

public class CreateFacilityCommandHandler(IFacilityRepository facilityRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateFacilityCommand, ErrorOr<Facility>>
{
    public async Task<ErrorOr<Facility>> Handle(CreateFacilityCommand request, CancellationToken cancellationToken)
    {
        var facility = new Facility(request.Name, request.Type, request.Location);

        await facilityRepository.AddAsync(facility);

        await unitOfWork.CommitChangesAsync();

        return facility;
    }
}