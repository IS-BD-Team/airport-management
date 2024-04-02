using AirportManagement.Application.Airplanes.Commands.CreateAirplane;
using AirportManagement.Application.Airplanes.Commands.DeleteAirplane;
using AirportManagement.Application.Airplanes.Commands.UpdateAirplane;
using AirportManagement.Application.Airplanes.Queries.GetAirplane;
using AirportManagement.Application.Airplanes.Queries.GetAllAirplanes;
using AirportManagement.Application.DTO;
using AirportManagement.Contracts.Airplanes;
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
public class AirplanesController(ISender mediator, IMapper mapper) : ODataController
{
    [HttpPost]
    public async Task<IActionResult> CreateAirplane(AirplaneRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var command = new CreateAirplaneCommand(
            request.Classification,
            request.PlanePlate,
            request.ClientId,
            request.MaxLoad,
            request.PassengersCapacity,
            request.CrewMembers);

        var createAirplaneResult = await mediator.Send(command);


        return createAirplaneResult.MatchFirst(
            airplane => Ok(mapper.Map<AirplaneDto>(airplane)),
            _ => Problem());
    }

    [HttpGet]
    [EnableQuery(MaxAnyAllExpressionDepth = 20)]
    public async Task<ActionResult> GetAirplanes()
    {
        var query = new GetAllAirplanesQuery();

        var getAirplanesResult = await mediator.Send(query);

        return getAirplanesResult.MatchFirst(
            Ok,
            error => Problem(error.Code, statusCode: error.NumericType));
    }

    [HttpGet("{airplaneId:int}")]
    public async Task<IActionResult> GetAirplane(int airplaneId)
    {
        var query = new GetAirplaneQuery(airplaneId);

        var getAirplaneResult = await mediator.Send(query);

        return getAirplaneResult.MatchFirst(
            airplane => Ok(mapper.Map<AirplaneDto>(airplane)),
            error => Problem(error.Code, statusCode: error.NumericType));
    }

    [HttpPut("{airplaneId:int}")]
    public async Task<IActionResult> UpdateAirplane(int airplaneId, AirplaneRequest request)
    {
        var command = new UpdateAirplaneCommand(
            airplaneId,
            request.Classification,
            request.PlanePlate,
            request.ClientId,
            request.MaxLoad,
            request.PassengersCapacity,
            request.CrewMembers);

        var updateAirplaneResult = await mediator.Send(command);

        return updateAirplaneResult.MatchFirst(
            airplane => Ok(mapper.Map<AirplaneDto>(airplane)),
            error => Problem(error.Code, statusCode: error.NumericType));
    }

    [HttpDelete("{airplaneId:int}")]
    public async Task<IActionResult> DeleteAirplane(int airplaneId)
    {
        var command = new DeleteAirplaneCommand(airplaneId);

        var deleteAirplaneResult = await mediator.Send(command);

        return deleteAirplaneResult.MatchFirst(
            _ => Ok(StatusCode(200)), error => Problem(error.Code, statusCode: error.NumericType));
    }
}