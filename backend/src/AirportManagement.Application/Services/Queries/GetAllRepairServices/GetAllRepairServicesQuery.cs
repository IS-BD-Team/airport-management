using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Queries.GetAllRepairServices;

public record GetAllRepairServicesQuery : IRequest<ErrorOr<IEnumerable<RepairService>>>;