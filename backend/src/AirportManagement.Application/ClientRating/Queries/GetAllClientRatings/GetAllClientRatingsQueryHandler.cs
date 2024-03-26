using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.ClientRating.Queries.GetAllClientRatings;

public class GetClientRatingsQueryHandler(IClientRatingRepository clientRatingRepository)
    : IRequestHandler<GetAllClientRatingsQuery, ErrorOr<IEnumerable<Domain.Clients.ClientRating>>>
{
    public async Task<ErrorOr<IEnumerable<Domain.Clients.ClientRating>>> Handle(GetAllClientRatingsQuery request,
        CancellationToken cancellationToken)
    {
        var clientRatings = await clientRatingRepository.GetAllAsync();

        return clientRatings.ToList();
    }
}