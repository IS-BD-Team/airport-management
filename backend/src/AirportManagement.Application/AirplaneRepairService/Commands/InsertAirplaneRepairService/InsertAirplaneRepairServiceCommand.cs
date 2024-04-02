using ErrorOr;
using MediatR;

namespace AirportManagement.Application.AirplaneRepairService.Commands.InsertAirplaneRepairService;

public record InsertAirplaneRepairServiceCommand(int FatherServiceId, int ChildServiceId) : IRequest<ErrorOr<Success>>;