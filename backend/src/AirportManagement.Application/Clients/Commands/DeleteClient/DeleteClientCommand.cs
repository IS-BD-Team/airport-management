using AirportManagement.Domain.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Clients.Commands.DeleteClient;

public abstract record DeleteClientCommand(int ClientId) : IRequest<ErrorOr<Client>>;