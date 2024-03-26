using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.ClientRating.Commands.UpdateClientRating;

public class
    UpdateClientRatingCommandHandler(IClientRatingRepository clientRatingRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateClientRatingCommand, ErrorOr<Domain.Clients.ClientRating>>
{
    public async Task<ErrorOr<Domain.Clients.ClientRating>> Handle(UpdateClientRatingCommand request,
        CancellationToken cancellationToken)
    {
        var existingClientRating = await clientRatingRepository.GetByIdAsync(request.RatingIid);

        if (existingClientRating is null)
            return Error.NotFound(
                $"Client rating with id {request.RatingIid} was not found.");

        existingClientRating.Rating = request.Rating;

        await unitOfWork.CommitChangesAsync();

        return existingClientRating;
    }
}