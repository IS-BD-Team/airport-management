using ErrorOr;
using MediatR;

namespace AirportManagement.Application.ClientRating.Commands.CreateClientRating;

public record CreateClientRatingCommand(int Rating, int ClientId, int ServiceId)
    : IRequest<ErrorOr<Domain.Clients.ClientRating>>;