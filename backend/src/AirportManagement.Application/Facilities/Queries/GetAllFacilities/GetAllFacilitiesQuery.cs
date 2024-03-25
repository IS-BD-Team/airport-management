using AirportManagement.Domain.Facility;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Facilities.Queries.GetAllFacilities;

public record GetAllFacilitiesQuery : IRequest<ErrorOr<IEnumerable<Facility>>>;