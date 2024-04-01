using ErrorOr;
using MediatR;

namespace AirportManagement.Application.AirplaneRepairService.Queries.GetAllAirplaneRepairServices;

public record GetAllAirplaneRepairServicesQuery :
    IRequest<ErrorOr<IQueryable<Domain.AirplaneRepairService.AirplaneRepairService>>>;