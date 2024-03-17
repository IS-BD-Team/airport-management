using AirportManagement.Domain.Airports;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airports.Queries;

public record GetAirportQuery(int AirportId)
    : IRequest<ErrorOr<Airport>>;