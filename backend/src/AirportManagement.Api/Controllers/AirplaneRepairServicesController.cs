using AirportManagement.Application.DTO;
using AirportManagement.Application.Services.AirplaneRepairService.Commands.CreateAirplaneRepairService;
using AirportManagement.Application.Services.AirplaneRepairService.Commands.DeleteAirplaneRepairService;
using AirportManagement.Application.Services.AirplaneRepairService.Commands.UpdateAirplaneRepairService;
using AirportManagement.Application.Services.AirplaneRepairService.Queries.GetAirplaneRepairService;
using AirportManagement.Application.Services.AirplaneRepairService.Queries.GetAllAirplaneRepairServices;
using AirportManagement.Contracts.Services;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagement.Api.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class AirplaneRepairServicesController(ISender mediator, IMapper mapper) : ControllerBase
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
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllAirplaneRepairServicesQuery();
        var queryResult = await mediator.Send(query);

        return queryResult.MatchFirst(
            services => Ok(
                services.Select(mapper.Map<AirplaneRepairServiceDto>).ToList()),
            _ => Problem());
    }
}