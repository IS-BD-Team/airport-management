using AirportManagement.Domain.Airports;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airports.Commands.UpdateAirport;

public record UpdateAirportCommand(int Id, string Name, string Address) : IRequest<ErrorOr<Airport>>;