using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.AirplaneRepairService.Queries.GetAirplaneRepairService;

public record GetAirplaneRepairServiceQuery(int ServiceId)
    : IRequest<ErrorOr<Domain.Services.AirplaneRepairService.AirplaneRepairService>>;