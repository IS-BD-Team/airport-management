using AirportManagement.Domain.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Clients.Queries.GetAllClients;

public record GetAllClientsQuery : IRequest<ErrorOr<IQueryable<Client>>>;