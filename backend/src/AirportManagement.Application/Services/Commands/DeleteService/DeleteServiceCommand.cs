using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Commands.DeleteService;

public record DeleteServiceCommand(int ServiceId) : IRequest<ErrorOr<Success>>;