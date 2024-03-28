using AirportManagement.Application.Airplanes.Commands.CreateAirplane;
using AirportManagement.Application.Airplanes.Commands.DeleteAirplane;
using AirportManagement.Application.Airplanes.Commands.UpdateAirplane;
using AirportManagement.Application.Airplanes.Queries.GetAirplane;
using AirportManagement.Application.Airplanes.Queries.GetAllAirplanes;
using AirportManagement.Contracts.Airplanes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AirportManagement.Api.Utils.ResponseCreator;

namespace AirportManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AirplanesController(ISender mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAirplane(AirplaneRequest request)
    {
        var command = new CreateAirplaneCommand(
            request.Classification,
            request.PlanePlate,
            request.ClientId,
            request.MaxLoad,
            request.PassengersCapacity,
            request.CrewMembers);

        var createAirplaneResult = await mediator.Send(command);

        return createAirplaneResult.MatchFirst(
            airplane => Ok(CreateAirplaneResponse(airplane)),
            _ => Problem());
    }

    [HttpGet]
    public async Task<IActionResult> GetAirplanes()
    {
        var query = new GetAllAirplanesQuery();

        var getAirplanesResult = await mediator.Send(query);

        return getAirplanesResult.MatchFirst(
            airplanes => Ok(airplanes.Select(CreateAirplaneResponse)),
            error => Problem(error.Code, statusCode: error.NumericType));
    }

    [HttpGet("{airplaneId:int}")]
    public async Task<IActionResult> GetAirplane(int airplaneId)
    {
        var query = new GetAirplaneQuery(airplaneId);

        var getAirplaneResult = await mediator.Send(query);

        return getAirplaneResult.MatchFirst(
            airplane => Ok(CreateAirplaneResponse(airplane)),
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
            airplane => Ok(CreateAirplaneResponse(airplane)),
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