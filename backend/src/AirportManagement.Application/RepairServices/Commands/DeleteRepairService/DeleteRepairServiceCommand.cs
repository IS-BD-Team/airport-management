using ErrorOr;
using MediatR;

namespace AirportManagement.Application.RepairServices.Commands.DeleteRepairService;

public record DeleteRepairServiceCommand(int ServiceId) : IRequest<ErrorOr<Success>>;