using AirportManagement.Domain.Airports;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airports.Commands.DeleteAirport;

public record DeleteAirportCommand(int AirportId)
    : IRequest<ErrorOr<Airport>>;