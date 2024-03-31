using AirportManagement.Domain.RepairServices;
using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.RepairServices.Queries.GetAllRepairServices;

public record GetAllRepairServicesQuery : IRequest<ErrorOr<IQueryable<RepairService>>>;