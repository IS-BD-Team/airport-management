using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Commands.DeleteService;

public class DeleteServiceCommandHandler(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteServiceCommand, ErrorOr<Service>>
{
    public async Task<ErrorOr<Service>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await serviceRepository.DeleteAsync(request.ServiceId);
        await unitOfWork.CommitChangesAsync();

        return service is null
            ? Error.NotFound($"Service with id: {request.ServiceId} was not found.")
            : service;
    }
}