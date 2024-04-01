using AirportManagement.Application.DTO;
using AirportManagement.Application.PlaneStays.Commands.CreatePlaneStay;
using AirportManagement.Application.PlaneStays.Commands.DeletePlaneStay;
using AirportManagement.Application.PlaneStays.Commands.UpdatePlaneStay;
using AirportManagement.Application.PlaneStays.Queries.QueryAllPlaneStays;
using AirportManagement.Application.PlaneStays.Queries.QueryPlaneStay;
using AirportManagement.Contracts.Airplanes;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace AirportManagement.Api.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class PlaneStayController(ISender mediator, IMapper mapper) : ODataController
{
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeletePlaneStayCommand(id);
        var deleteResult = await mediator.Send(command);

        return deleteResult.MatchFirst(_ => Ok(204),
            _ => Problem());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetPlaneStayQuery(id);
        var queryResponseResult = await mediator.Send(query);

        return queryResponseResult.MatchFirst(
            stay => Ok(mapper.Map<PlaneStayDto>(stay)),
            _ => Problem());
    }

    [HttpPost]
    public async Task<IActionResult> Create(PlaneStayRequest request)
    {
        var command = new CreatePlaneStayCommand(request.AirplaneId, request.AirportId, request.ArrivalDate,
            request.DepartureDate);
        var createStayResult = await mediator.Send(command);

        return createStayResult.MatchFirst(
            stay => Ok(mapper.Map<PlaneStayDto>(stay)),
            _ => Problem());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, PlaneStayRequest request)
    {
        var command = new UpdatePlaneStayCommand(id, request.AirplaneId, request.AirportId, request.ArrivalDate,
            request.DepartureDate);

        var result = await mediator.Send(command);

        return result.MatchFirst(stay => Ok(mapper.Map<PlaneStayDto>(stay)),
            _ => Problem());
    }

    [HttpGet]
    [EnableQuery]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllPlaneStaysQuery();
        var queryResponseResult = await mediator.Send(query);

        return queryResponseResult.MatchFirst(
            Ok,
            _ => Problem());
    }
}