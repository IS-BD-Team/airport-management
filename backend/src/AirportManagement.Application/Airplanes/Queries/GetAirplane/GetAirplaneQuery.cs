using AirportManagement.Domain.Airplane;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airplanes.Queries.GetAirplane;

public record GetAirplaneQuery(int Id) : IRequest<ErrorOr<Airplane>>;