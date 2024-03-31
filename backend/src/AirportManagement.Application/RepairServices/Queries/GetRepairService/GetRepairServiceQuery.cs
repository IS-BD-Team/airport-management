using AirportManagement.Domain.RepairServices;
using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.RepairServices.Queries.GetRepairService;

public record GetRepairServiceQuery(int ServiceId) : IRequest<ErrorOr<RepairService>>;