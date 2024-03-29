using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Commands.CreateRepairService;

public record CreateRepairServiceCommand(string Description, int FacilityId, decimal Price, string Type)
    : IRequest<ErrorOr<RepairService>>;