using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Commands.DeleteRepairService;

public record DeleteRepairServiceCommand(int ServiceId) : IRequest<ErrorOr<Success>>;