using AirportManagement.Domain.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Clients.Commands.UpdateClient;

public record UpdateClientCommand(
    int Id,
    string Name,
    string Ci,
    string Country,
    string ArrivalRole,
    string ClientType) : IRequest<ErrorOr<Client>>;