using AirportManagement.Application.DTO;
using AirportManagement.Application.Services.Commands.CreateRepairService;
using AirportManagement.Application.Services.Commands.DeleteRepairService;
using AirportManagement.Application.Services.Commands.UpdateRepairService;
using AirportManagement.Application.Services.Queries.GetAllRepairServices;
using AirportManagement.Application.Services.Queries.GetRepairService;
using AirportManagement.Contracts.Services;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagement.Api.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class RepairServicesController(ISender mediator, IMapper mapper) : ControllerBase
{
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteRepairServiceCommand(id);
        var deleteResult = await mediator.Send(command);

        return deleteResult.MatchFirst(_ => Ok(204),
            _ => Problem());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetRepairServiceQuery(id);
        var queryResponseResult = await mediator.Send(query);

        return queryResponseResult.MatchFirst(
            service => Ok(mapper.Map<RepairServiceDto>(service)),
            _ => Problem());
    }

    [HttpPost]
    public async Task<IActionResult> Create(RepairServiceRequest request)
    {
        var command =
            new CreateRepairServiceCommand(request.Description, request.FacilityId, request.Price, request.Type);
        var createServiceResult = await mediator.Send(command);

        return createServiceResult.MatchFirst(
            service => Ok(mapper.Map<RepairServiceDto>(service)),
            _ => Problem());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, RepairServiceRequest request)
    {
        var command =
            new UpdateRepairServiceCommand(id, request.Description, request.FacilityId, request.Price, request.Type);

        var result = await mediator.Send(command);

        return result.MatchFirst(service => Ok(mapper.Map<RepairServiceDto>(service)), _ => Problem());
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllRepairServicesQuery();
        var queryResponseResult = await mediator.Send(query);

        return queryResponseResult.MatchFirst(
            services => Ok(services.Select(mapper.Map<RepairServiceDto>).ToList()),
            _ => Problem());
    }
}