using AirportManagement.Domain.Airports;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airports.Queries.GetAllAirports;

public record GetAllAirportsQuery
    : IRequest<ErrorOr<IQueryable<Airport>>>;