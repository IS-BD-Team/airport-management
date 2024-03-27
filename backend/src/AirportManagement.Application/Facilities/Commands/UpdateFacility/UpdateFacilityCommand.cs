using AirportManagement.Domain.Facility;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Facilities.Commands.UpdateFacility;

public record UpdateFacilityCommand(
    int Id,
    string? Name,
    string Type,
    string Location,
    int AirportId) : IRequest<ErrorOr<Facility>>;