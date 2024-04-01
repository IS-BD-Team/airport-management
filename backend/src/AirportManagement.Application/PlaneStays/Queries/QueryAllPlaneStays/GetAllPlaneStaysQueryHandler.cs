using AirportManagement.Application.Common.Interfaces.Persistence.PlaneStay;
using AirportManagement.Domain.PlaneStay;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.PlaneStays.Queries.QueryAllPlaneStays;

public class GetAllPlaneStaysQueryHandler(IPlaneStayRepository planeStayRepository)
    : IRequestHandler<GetAllPlaneStaysQuery, ErrorOr<IQueryable<PlaneStay>>>
{
    public async Task<ErrorOr<IQueryable<PlaneStay>>> Handle(GetAllPlaneStaysQuery request,
        CancellationToken cancellationToken)
    {
        var planeStays = await planeStayRepository.GetAllAsync();
        return planeStays.ToErrorOr();
    }
}