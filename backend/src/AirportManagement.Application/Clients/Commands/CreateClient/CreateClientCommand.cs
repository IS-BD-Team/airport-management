using AirportManagement.Domain.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Clients.Commands.CreateClient;

public record CreateClientCommand(
    string Name,
    string Ci,
    string Country,
    string ArrivalRole,
    string ClientType) : IRequest<ErrorOr<Client>>;