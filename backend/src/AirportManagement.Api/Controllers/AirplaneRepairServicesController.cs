using AirportManagement.Application.AirplaneRepairService.Commands.CreateAirplaneRepairService;
using AirportManagement.Application.AirplaneRepairService.Commands.DeleteAirplaneRepairService;
using AirportManagement.Application.AirplaneRepairService.Commands.UpdateAirplaneRepairService;
using AirportManagement.Application.AirplaneRepairService.Queries.GetAirplaneRepairService;
using AirportManagement.Application.AirplaneRepairService.Queries.GetAllAirplaneRepairServices;
using AirportManagement.Application.DTO;
using AirportManagement.Contracts.Services;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace AirportManagement.Api.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class AirplaneRepairServicesController(ISender mediator, IMapper mapper) : ODataController
{
    [HttpPost]
    public async Task<IActionResult> Create(AirplaneRepairServiceRequest request)
    {
        var command = new CreateAirplaneRepairServiceCommand(
            request.AirPlaneId,
            request.RepairServiceId,
            request.StartDate,
            request.EndDate);

        var createResult = await mediator.Send(command);

        return createResult.MatchFirst(
            service => Ok(mapper.Map<AirplaneRepairServiceDto>(service)),
            _ => Problem());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteAirplaneRepairServiceCommand(id);
        var deleteResult = await mediator.Send(command);

        return deleteResult.MatchFirst(_ => Ok(204), _ => Problem());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, AirplaneRepairServiceRequest request)
    {
        var command = new UpdateAirplaneRepairServiceCommand(id,
            request.AirPlaneId,
            request.RepairServiceId,
            request.StartDate,
            request.EndDate);

        var updateResult = await mediator.Send(command);

        return updateResult.MatchFirst(
            service => Ok(mapper.Map<AirplaneRepairServiceDto>(service)),
            _ => Problem());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetAirplaneRepairServiceQuery(id);
        var queryResult = await mediator.Send(query);

        return queryResult.MatchFirst(
            service => Ok(mapper.Map<AirplaneRepairServiceDto>(service)),
            _ => Problem());
    }

    [HttpGet]
    [EnableQuery]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllAirplaneRepairServicesQuery();
        var queryResult = await mediator.Send(query);

        return queryResult.MatchFirst(
            Ok,
            _ => Problem());
    }
}