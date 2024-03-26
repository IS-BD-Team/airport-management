using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.ClientRating.Queries.GetClientRating;

public class GetClientRatingQueryHandler(IClientRatingRepository clientRatingRepository)
    : IRequestHandler<GetClientRatingQuery, ErrorOr<Domain.Clients.ClientRating>>
{
    public async Task<ErrorOr<Domain.Clients.ClientRating>> Handle(GetClientRatingQuery request,
        CancellationToken cancellationToken)
    {
        var clientRating = await clientRatingRepository.GetByIdAsync(request.ClientRatingId);

        if (clientRating is null)
            return Error.NotFound(
                $"Client rating with id {request.ClientRatingId} was not found.");

        return clientRating;
    }
}