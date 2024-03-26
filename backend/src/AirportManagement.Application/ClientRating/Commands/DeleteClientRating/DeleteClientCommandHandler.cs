using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.ClientRating.Commands.DeleteClientRating;

public class DeleteClientRatingCommandHandler(IClientRatingRepository clientRatingRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteClientRatingCommand, ErrorOr<Domain.Clients.ClientRating>>
{
    public async Task<ErrorOr<Domain.Clients.ClientRating>> Handle(DeleteClientRatingCommand request,
        CancellationToken cancellationToken)
    {
        var clientRating = await clientRatingRepository.DeleteAsync(request.RatingId);

        if (clientRating is null)
            return Error.NotFound(
                $"Client rating with id {request.RatingId} was not found. It may have been deleted already.");

        await unitOfWork.CommitChangesAsync();

        return clientRating;
    }
}