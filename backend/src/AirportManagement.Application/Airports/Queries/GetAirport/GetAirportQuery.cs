using AirportManagement.Domain.Airports;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airports.Queries.GetAirport;

public record GetAirportQuery(int AirportId)
    : IRequest<ErrorOr<Airport>>;