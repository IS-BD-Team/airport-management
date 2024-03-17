using AirportManagement.Domain.Airports;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airports.Commands.CreateAirport;

public record CreateAirportCommand(string Name, string Address)
    : IRequest<ErrorOr<Airport>>;