using AirportManagement.Application.DTO;
using AirportManagement.Application.Services.Commands.CreateService;
using AirportManagement.Application.Services.Commands.DeleteService;
using AirportManagement.Application.Services.Commands.UpdateService;
using AirportManagement.Application.Services.Queries.GetAllServices;
using AirportManagement.Application.Services.Queries.GetService;
using AirportManagement.Contracts.Services;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace AirportManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ServicesController(ISender mediator, IMapper mapper) : ODataController
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
            service => Ok(mapper.Map<ServiceDto>(service)),
            _ => Problem());
    }

    [HttpGet]
    [EnableQuery]
    public async Task<IActionResult> GetServices()
    {
        var query = new GetAllServicesQuery();

        var getServicesResult = await mediator.Send(query);

        return getServicesResult.MatchFirst(
            Ok,
            error => Problem());
    }

    [HttpGet("{serviceId:int}")]
    public async Task<IActionResult> GetService(int serviceId)
    {
        var query = new GetServiceQuery(serviceId);

        var getServiceResult = await mediator.Send(query);

        return getServiceResult.MatchFirst(
            service => Ok(mapper.Map<ServiceDto>(service)),
            error => Problem());
    }

    [HttpPut("{serviceId:int}")]
    public async Task<IActionResult> UpdateService(int serviceId, ServiceRequest request)
    {
        var command = new UpdateServiceCommand(serviceId, request.Description, request.FacilityId, request.Price);

        var updateServiceResult = await mediator.Send(command);

        return updateServiceResult.MatchFirst(
            service => Ok(mapper.Map<ServiceDto>(service)),
            error => Problem());
    }

    [HttpDelete("{serviceId:int}")]
    public async Task<IActionResult> DeleteService(int serviceId)
    {
        var command = new DeleteServiceCommand(serviceId);

        var deleteServiceResult = await mediator.Send(command);

        return deleteServiceResult.MatchFirst(
            _ => Ok(StatusCode(204)),
            error => Problem());
    }
}