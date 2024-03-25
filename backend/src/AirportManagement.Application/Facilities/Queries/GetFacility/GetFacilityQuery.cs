using AirportManagement.Domain.Facility;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Facilities.Queries.GetFacility;

public record GetFacilityQuery(int FacilityId) : IRequest<ErrorOr<Facility>>;