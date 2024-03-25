using AirportManagement.Application.Common.Interfaces.Persistence.Facilities;
using AirportManagement.Domain.Facility;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Facilities.Queries.GetAllFacilities;

public class GetFacilitiesQueryHandler(IFacilityRepository facilityRepository)
    : IRequestHandler<GetAllFacilitiesQuery, ErrorOr<IEnumerable<Facility>>>
{
    public async Task<ErrorOr<IEnumerable<Facility>>> Handle(GetAllFacilitiesQuery request,
        CancellationToken cancellationToken)
    {
        var facilities = await facilityRepository.GetAllAsync();

        return facilities.ToList();
    }
}