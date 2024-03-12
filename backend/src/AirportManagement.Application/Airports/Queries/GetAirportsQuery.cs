using AirportManagement.Domain.Airports;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airports.Queries;

public record GetAirportsQuery
    : IRequest<ErrorOr<IEnumerable<Airport>>>;