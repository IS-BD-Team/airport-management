using AirportManagement.Application.Common.Interfaces.Persistence.PlaneStay;
using AirportManagement.Domain.PlaneStay;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.PlaneStays.Queries.QueryPlaneStay;

public class GetPlaneStayQueryHandler(IPlaneStayRepository planeStayRepository) :
    IRequestHandler<GetPlaneStayQuery, ErrorOr<PlaneStay>>
{
    public async Task<ErrorOr<PlaneStay>> Handle(GetPlaneStayQuery request, CancellationToken cancellationToken)
    {
        var planeStay = await planeStayRepository.GetByIdAsync(request.StayId);

        return planeStay is null ? Error.NotFound("Plane stay not found") : planeStay;
    }
}