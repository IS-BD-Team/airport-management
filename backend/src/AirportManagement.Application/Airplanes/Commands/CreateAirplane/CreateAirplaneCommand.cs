using AirportManagement.Domain.Airplane;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airplanes.Commands.CreateAirplane;

public record CreateAirplaneCommand(
    string Classification,
    int ClientId,
    int MaxLoad,
    int PassengersCapacity,
    int CrewMembers
)
    : IRequest<ErrorOr<Airplane>>;