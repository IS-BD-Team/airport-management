using AirportManagement.Application.Common.Interfaces.Persistence.PlaneStay;
using AirportManagement.Domain.PlaneStay;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.PlaneStays.Queries.QueryAllPlaneStays;

public class GetAllPlaneStaysQueryHandler(IPlaneStayRepository planeStayRepository)
    : IRequestHandler<GetAllPlaneStaysQuery, ErrorOr<IEnumerable<PlaneStay>>>
{
    public async Task<ErrorOr<IEnumerable<PlaneStay>>> Handle(GetAllPlaneStaysQuery request,
        CancellationToken cancellationToken)
    {
        var planeStays = await planeStayRepository.GetAllAsync();
        return planeStays.ToList();
    }
}