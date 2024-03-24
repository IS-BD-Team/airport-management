using AirportManagement.Domain.Airplane;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airplanes.Commands.UpdateAirplane;

public record UpdateAirplaneCommand(
    int Id,
    string Classification,
    int ClientId,
    int MaxLoad,
    DateTimeOffset ArriveDate,
    DateTimeOffset DepartureDate,
    bool HasReceivedMaintenance)
    : IRequest<ErrorOr<Airplane>>;