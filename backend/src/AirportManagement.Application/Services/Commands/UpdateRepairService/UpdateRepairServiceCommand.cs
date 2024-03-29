using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Commands.UpdateRepairService;

public record UpdateRepairServiceCommand(int ServiceId, string Description, int FacilityId, decimal Price, string Type)
    : IRequest<ErrorOr<RepairService>>;