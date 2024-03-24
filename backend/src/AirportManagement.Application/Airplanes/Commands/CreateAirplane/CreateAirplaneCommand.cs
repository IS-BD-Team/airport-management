using AirportManagement.Domain.Airplane;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Airplanes.Commands.CreateAirplane;

public record CreateAirplaneCommand(
    string Classification,
    int ClientId,
    int MaxLoad,
    DateTimeOffset ArriveDate,
    DateTimeOffset DepartureDate,
    bool HasReceivedMaintenance = false)
    : IRequest<ErrorOr<Airplane>>;