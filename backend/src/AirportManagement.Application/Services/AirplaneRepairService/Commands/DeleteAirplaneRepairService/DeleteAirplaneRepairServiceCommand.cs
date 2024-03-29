using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.AirplaneRepairService.Commands.DeleteAirplaneRepairService;

public record DeleteAirplaneRepairServiceCommand(int ServiceId) : IRequest<ErrorOr<Success>>;