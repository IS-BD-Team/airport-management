using ErrorOr;
using MediatR;

namespace AirportManagement.Application.ClientRating.Queries.GetAllClientRatings;

public record GetAllClientRatingsQuery : IRequest<ErrorOr<IQueryable<Domain.Clients.ClientRating>>>;