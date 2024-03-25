using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Commands.UpdateService;

public class UpdateServiceCommandHandler(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateServiceCommand, ErrorOr<Service>>
{
    public async Task<ErrorOr<Service>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var newServiceData = new Service(request.Description, request.FacilityId, request.Price);

        var service = await serviceRepository.UpdateAsync(request.Id, newServiceData);

        if (service is null) return Error.NotFound($"Service with id: {request.Id} was not found");

        await unitOfWork.CommitChangesAsync();

        return service;
    }
}