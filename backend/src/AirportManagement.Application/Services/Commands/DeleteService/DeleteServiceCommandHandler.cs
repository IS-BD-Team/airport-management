using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Commands.DeleteService;

public class DeleteServiceCommandHandler(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteServiceCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        await serviceRepository.DeleteAsync(request.ServiceId);
        await unitOfWork.CommitChangesAsync();

        return new Success();
    }
}