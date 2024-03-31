using AirportManagement.Domain.RepairServices;
using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.RepairServices.Commands.UpdateRepairService;

public record UpdateRepairServiceCommand(int ServiceId, string Description, int FacilityId, decimal Price, string Type)
    : IRequest<ErrorOr<RepairService>>;