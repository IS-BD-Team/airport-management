using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airplanes.Commands.DeleteAirplane;

public record DeleteAirplaneCommand(int Id) : IRequest<ErrorOr<Success>>;