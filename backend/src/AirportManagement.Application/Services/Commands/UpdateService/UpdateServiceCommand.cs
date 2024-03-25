using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Commands.UpdateService;

public record UpdateServiceCommand(
    int Id,
    string Description,
    int FacilityId,
    decimal Price) : IRequest<ErrorOr<Service>>;