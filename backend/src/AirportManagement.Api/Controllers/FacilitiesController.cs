using AirportManagement.Application.Facilities.Commands.CreateFacility;
using AirportManagement.Application.Facilities.Commands.DeleteFacility;
using AirportManagement.Application.Facilities.Commands.UpdateFacility;
using AirportManagement.Application.Facilities.Queries.GetAllFacilities;
using AirportManagement.Application.Facilities.Queries.GetFacility;
using AirportManagement.Contracts.Facilities;
using AirportManagement.Domain.Facility;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class FacilitiesController(ISender mediator) : ControllerBase
{
    private static FacilityResponse CreateFacilityResponse(Facility facility)
    {
        return new FacilityResponse(facility.Id, facility.Name, facility.Type, facility.Location);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFacility(FacilityRequest request)
    {
        var command = new CreateFacilityCommand(
            request.Name, request.Type, request.Location);

        var createFacilityResult = await mediator.Send(command);

        return createFacilityResult.MatchFirst(
            facility => Ok(CreateFacilityResponse(facility)),
            _ => Problem());
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFacilities()
    {
        var query = new GetAllFacilitiesQuery();

        var getFacilitiesResult = await mediator.Send(query);

        return getFacilitiesResult.MatchFirst(
            facilities => Ok(facilities.Select(CreateFacilityResponse).ToList()),
            error => Problem(error.Code, statusCode: error.NumericType));
    }

    [HttpGet("{facilityId:int}")]
    public async Task<IActionResult> GetFacility(int facilityId)
    {
        var query = new GetFacilityQuery(facilityId);
        var getFacilityResult = await mediator.Send(query);
        return getFacilityResult.MatchFirst(
            facility => Ok(CreateFacilityResponse(facility)),
            error => Problem(error.Code, statusCode: error.NumericType));
    }

    [HttpPut("{facilityId:int}")]
    public async Task<IActionResult> UpdateFacility(int facilityId, FacilityRequest request)
    {
        var command = new UpdateFacilityCommand(facilityId, request.Name, request.Type, request.Location);

        var updateFacilityResult = await mediator.Send(command);

        return updateFacilityResult.MatchFirst(
            facility => Ok(CreateFacilityResponse(facility)),
            error => Problem(error.Code, statusCode: error.NumericType));
    }

    [HttpDelete("{facilityId:int}")]
    public async Task<IActionResult> DeleteFacility(int facilityId)
    {
        var command = new DeleteFacilityCommand(facilityId);

        var deleteFacilityResult = await mediator.Send(command);

        return deleteFacilityResult.MatchFirst(
            _ => Ok(StatusCode(200)),
            error => Problem(error.Code, statusCode: error.NumericType));
    }
}