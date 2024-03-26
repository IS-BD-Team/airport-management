using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Clients;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.ClientRating.Commands.CreateClientRating;

public class
    CreateClientRatingCommandHandler(IClientRatingRepository clientRatingRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateClientRatingCommand, ErrorOr<Domain.Clients.ClientRating>>
{
    public async Task<ErrorOr<Domain.Clients.ClientRating>> Handle(CreateClientRatingCommand request,
        CancellationToken cancellationToken)
    {
        var clientRating = new Domain.Clients.ClientRating(request.Rating, request.ClientId, request.ServiceId);

        await clientRatingRepository.AddAsync(clientRating);

        await unitOfWork.CommitChangesAsync();

        return clientRating;
    }
}