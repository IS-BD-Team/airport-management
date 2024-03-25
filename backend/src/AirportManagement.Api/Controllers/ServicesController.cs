using AirportManagement.Application.Services.Commands.CreateService;
using AirportManagement.Application.Services.Commands.DeleteService;
using AirportManagement.Application.Services.Commands.UpdateService;
using AirportManagement.Application.Services.Queries.GetAllServices;
using AirportManagement.Application.Services.Queries.GetService;
using AirportManagement.Contracts.Services;
using AirportManagement.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ServicesController(ISender mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateService(ServiceRequest request)
    {
        var command = new CreateServiceCommand(
            request.Description,
            request.FacilityId,
            request.Price);

        var createServiceResult = await mediator.Send(command);

        return createServiceResult.MatchFirst(
            service => Ok(CreateServiceResponse(service)),
            _ => Problem());
    }

    [HttpGet]
    public async Task<IActionResult> GetServices()
    {
        var query = new GetAllServicesQuery();

        var getServicesResult = await mediator.Send(query);

        return getServicesResult.MatchFirst(
            services => Ok(services.Select(CreateServiceResponse).ToList()),
            error => Problem(error.Code, statusCode: error.NumericType));
    }

    [HttpGet("{serviceId:int}")]
    public async Task<IActionResult> GetService(int serviceId)
    {
        var query = new GetServiceQuery(serviceId);

        var getServiceResult = await mediator.Send(query);

        return getServiceResult.MatchFirst(
            service => Ok(CreateServiceResponse(service)),
            error => Problem(error.Code, statusCode: error.NumericType));
    }

    [HttpPut("{serviceId:int}")]
    public async Task<IActionResult> UpdateService(int serviceId, ServiceRequest request)
    {
        var command = new UpdateServiceCommand(serviceId, request.Description, request.FacilityId, request.Price);

        var updateServiceResult = await mediator.Send(command);

        return updateServiceResult.MatchFirst(
            service => Ok(CreateServiceResponse(service)),
            error => Problem(error.Code, statusCode: error.NumericType));
    }

    [HttpDelete("{serviceId:int}")]
    public async Task<IActionResult> DeleteService(int serviceId)
    {
        var command = new DeleteServiceCommand(serviceId);

        var deleteServiceResult = await mediator.Send(command);

        return deleteServiceResult.MatchFirst(
            _ => Ok(StatusCode(200)),
            error => Problem(error.Code, statusCode: error.NumericType));
    }

    private static ServiceResponse CreateServiceResponse(Service service)
    {
        return new ServiceResponse(
            service.Id,
            service.Description,
            service.FacilityId,
            service.Price);
    }
}