using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Application.Common.Interfaces.Persistence.Services;
using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Commands.CreateService;

public class CreateServiceCommandHandler(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateServiceCommand, ErrorOr<Service>>
{
    public async Task<ErrorOr<Service>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = new Service(request.Description, request.FacilityId, request.Price);

        await serviceRepository.AddAsync(service);

        await unitOfWork.CommitChangesAsync();

        return service;
    }
}