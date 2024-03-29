using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.AirplaneRepairService.Queries.GetAllAirplaneRepairServices;

public record GetAllAirplaneRepairServicesQuery :
    IRequest<ErrorOr<IEnumerable<Domain.Services.AirplaneRepairService.AirplaneRepairService>>>;