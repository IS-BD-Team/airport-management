using AirportManagement.Domain.Airplane;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airplanes.Commands.UpdateAirplane;

public record UpdateAirplaneCommand(
    int Id,
    string Classification,
    string PlanePlate,
    int ClientId,
    int MaxLoad,
    int PassengersCapacity,
    int CrewMembers
)
    : IRequest<ErrorOr<Airplane>>;