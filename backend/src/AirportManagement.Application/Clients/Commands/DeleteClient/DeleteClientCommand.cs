using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Clients.Commands.DeleteClient;

public record DeleteClientCommand(int ClientId) : IRequest<ErrorOr<Success>>;