using AirportManagement.Domain.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Clients.Commands.CreateClient;

public abstract record CreateClientCommand(
    string Name,
    ClientType ClientType,
    string Ci,
    string Country,
    ArrivalRole ArrivalRole) : IRequest<ErrorOr<Client>>;