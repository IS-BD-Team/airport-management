using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.ClientRating.Commands.DeleteClientRating;

public class DeleteClientRatingCommandHandler(IClientRatingRepository clientRatingRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteClientRatingCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteClientRatingCommand request,
        CancellationToken cancellationToken)
    {
        await clientRatingRepository.DeleteAsync(request.RatingId);
        await unitOfWork.CommitChangesAsync();
        return new Success();
    }
}