using ErrorOr;
using MediatR;

namespace AirportManagement.Application.ClientRating.Queries.GetClientRating;

public record GetClientRatingQuery(int ClientRatingId) : IRequest<ErrorOr<Domain.Clients.ClientRating>>;