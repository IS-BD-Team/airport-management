using ErrorOr;
using MediatR;

namespace AirportManagement.Application.ClientRating.Commands.UpdateClientRating;

public record UpdateClientRatingCommand(int RatingId, int Rating)
    : IRequest<ErrorOr<Domain.Clients.ClientRating>>;