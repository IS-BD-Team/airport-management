using AirportManagement.Domain.Airplane;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airplanes.Queries.GetAllAirplanes;

public record GetAllAirplanesQuery : IRequest<ErrorOr<IQueryable<Airplane>>>;