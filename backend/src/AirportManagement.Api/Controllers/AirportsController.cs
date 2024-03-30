using AirportManagement.Application.Airports.Commands.CreateAirport;
using AirportManagement.Application.Airports.Commands.DeleteAirport;
using AirportManagement.Application.Airports.Commands.UpdateAirport;
using AirportManagement.Application.Airports.Queries;
using AirportManagement.Application.DTO;
using AirportManagement.Contracts.Airports;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AirportsController(ISender mediator, IMapper mapper)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAirport(AirportRequest request)
    {
        var command = new CreateAirportCommand(request.Name, request.Address, request.GeographicLocation);

        var createAirportResult = await mediator.Send(command);
        return createAirportResult.MatchFirst(
            airport => Ok(mapper.Map<AirportDto>(airport)),
            _ => Problem());
    }

    [HttpGet]
    public async Task<IActionResult> GetAirports()
    {
        var query = new GetAirportsQuery();

        var getAirportsResult = await mediator.Send(query);

        return getAirportsResult.MatchFirst(
            airports => Ok(airports.Select(mapper.Map<AirportDto>).ToList()),
            error => Problem(error.Code, statusCode: error.NumericType)
        );
    }

    [HttpGet("{airportId:int}")]
    public async Task<IActionResult> GetAirport(int airportId)
    {
        var query = new GetAirportQuery(airportId);

        var getAirportResult = await mediator.Send(query);

        return getAirportResult.MatchFirst(
            airport => Ok(mapper.Map<AirportDto>(airport)),
            error => Problem(error.Code, statusCode: error.NumericType)
        );
    }

    [HttpDelete("{airportId:int}")]
    public async Task<IActionResult> DeleteAirport(int airportId)
    {
        var command = new DeleteAirportCommand(airportId);

        var deleteAirportResult = await mediator.Send(command);

        return deleteAirportResult.MatchFirst(
            airport => Ok(mapper.Map<AirportDto>(airport)),
            error => Problem(error.Code, statusCode: error.NumericType)
        );
    }

    [HttpPut("{airportId:int}")]
    public async Task<IActionResult> UpdateAirport(int airportId, AirportRequest request)
    {
        var command = new UpdateAirportCommand(airportId, request.Name, request.Address, request.GeographicLocation);

        var updateAirportResult = await mediator.Send(command);

        return updateAirportResult.MatchFirst(
            airport => Ok(mapper.Map<AirportDto>(airport)),
            error => Problem(error.Code, statusCode: error.NumericType)
        );
    }
}