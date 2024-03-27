using AirportManagement.Application.Common.Interfaces.Persistence.Facilities;
using AirportManagement.Domain.Facility;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Facilities.Queries.GetFacility;

public class GetFacilityQueryHandler(IFacilityRepository facilityRepository)
    : IRequestHandler<GetFacilityQuery, ErrorOr<Facility>>
{
    public async Task<ErrorOr<Facility>> Handle(GetFacilityQuery request, CancellationToken cancellationToken)
    {
        var facility = await facilityRepository.GetByIdAsync(request.FacilityId);

        return facility is null
            ? Error.NotFound($"Facility with id: {request.FacilityId} was not found.")
            : facility;
    }
}