using AirportManagement.Domain.PlaneStay;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.PlaneStays.Queries.QueryPlaneStay;

public record GetPlaneStayQuery(int StayId) : IRequest<ErrorOr<PlaneStay>>;