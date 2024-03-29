using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.AirplaneRepairService.Commands.UpdateAirplaneRepairService;

public record UpdateAirplaneRepairServiceCommand(
    int ServiceId,
    int AirPlaneId,
    int RepairServiceId,
    DateTime StartDate,
    DateTime EndDate)
    : IRequest<ErrorOr<Domain.Services.AirplaneRepairService.AirplaneRepairService>>;