using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Queries.GetRepairService;

public record GetRepairServiceQuery(int ServiceId) : IRequest<ErrorOr<RepairService>>;