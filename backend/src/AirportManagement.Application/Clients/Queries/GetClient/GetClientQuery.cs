using AirportManagement.Domain.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Clients.Queries.GetClient;

public abstract record GetClientQuery(int ClientId) : IRequest<ErrorOr<Client>>;