using ErrorOr;
using MediatR;

namespace AirportManagement.Application.ClientRating.Commands.DeleteClientRating;

public record DeleteClientRatingCommand(int RatingId) : IRequest<ErrorOr<Success>>;