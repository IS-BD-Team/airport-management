using ErrorOr;
using MediatR;

namespace AirportManagement.Application.AirplaneRepairService.Queries.GetAirplaneRepairService;

public record GetAirplaneRepairServiceQuery(int ServiceId)
    : IRequest<ErrorOr<Domain.AirplaneRepairService.AirplaneRepairService>>;