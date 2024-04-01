using ErrorOr;
using MediatR;

namespace AirportManagement.Application.AirplaneRepairService.Commands.CreateAirplaneRepairService;

public record CreateAirplaneRepairServiceCommand(
    int AirPlaneId,
    int RepairServiceId,
    DateTime StartDate,
    DateTime EndDate)
    : IRequest<ErrorOr<Domain.AirplaneRepairService.AirplaneRepairService>>;