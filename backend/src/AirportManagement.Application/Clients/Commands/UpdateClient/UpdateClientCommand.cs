using AirportManagement.Domain.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Clients.Commands.UpdateClient;

public abstract record UpdateClientCommand(
    int Id,
    string Name,
    string Ci,
    string Country,
    ArrivalRole ArrivalRole,
    ClientType ClientType) : IRequest<ErrorOr<Client>>;