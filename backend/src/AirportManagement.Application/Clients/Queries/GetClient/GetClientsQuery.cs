using AirportManagement.Domain.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Clients.Queries.GetClient;

public record GetClientsQuery : IRequest<ErrorOr<IEnumerable<Client>>>;