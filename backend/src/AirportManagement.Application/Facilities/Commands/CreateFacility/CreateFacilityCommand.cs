using AirportManagement.Domain.Facility;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Facilities.Commands.CreateFacility;

public record CreateFacilityCommand(
    string? Name,
    string Type,
    string Location,
    int AirportId) : IRequest<ErrorOr<Facility>>;