using AirportManagement.Domain.PlaneStay;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.PlaneStays.Queries.QueryAllPlaneStays;

public record GetAllPlaneStaysQuery : IRequest<ErrorOr<IQueryable<PlaneStay>>>;