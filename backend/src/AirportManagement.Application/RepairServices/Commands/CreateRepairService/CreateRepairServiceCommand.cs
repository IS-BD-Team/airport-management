using AirportManagement.Domain.RepairServices;
using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.RepairServices.Commands.CreateRepairService;

public record CreateRepairServiceCommand(string Description, int FacilityId, decimal Price, string Type)
    : IRequest<ErrorOr<RepairService>>;