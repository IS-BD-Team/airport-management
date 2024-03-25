using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Commands.CreateService;

public record CreateServiceCommand(
    string Description,
    int FacilityId,
    decimal Price) : IRequest<ErrorOr<Service>>;