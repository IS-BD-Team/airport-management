using AirportManagement.Application.ClientRating.Commands.CreateClientRating;
using AirportManagement.Application.ClientRating.Commands.DeleteClientRating;
using AirportManagement.Application.ClientRating.Commands.UpdateClientRating;
using AirportManagement.Application.ClientRating.Queries.GetAllClientRatings;
using AirportManagement.Application.ClientRating.Queries.GetClientRating;
using AirportManagement.Application.DTO;
using AirportManagement.Contracts.ClientRating;
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
public class ClientRatingsController(ISender mediator, IMapper mapper) : ODataController
{
    [HttpPost]
    public async Task<IActionResult> CreateClientRating(ClientRatingRequest request)
    {
        var command = new CreateClientRatingCommand(request.Rating, request.ClientId, request.ServiceId);
        var result = await mediator.Send(command);

        return result.Match(
            clientRating => Ok(mapper.Map<ClientRatingDto>(clientRating)),
            error => Problem());
    }

    [HttpDelete("ratingId")]
    public async Task<IActionResult> DeleteClientRating(int ratingId)
    {
        var command = new DeleteClientRatingCommand(ratingId);
        var result = await mediator.Send(command);

        return result.Match(
            clientRating => Ok(204),
            error => Problem());
    }

    [HttpPut("{ratingId}")]
    public async Task<IActionResult> UpdateClientRating(int ratingId, ClientRatingRequest request)
    {
        var command = new UpdateClientRatingCommand(ratingId, request.Rating);
        var result = await mediator.Send(command);

        return result.Match(
            clientRating => Ok(mapper.Map<ClientRatingDto>(clientRating)),
            error => Problem());
    }

    [HttpGet("{ratingId}")]
    public async Task<IActionResult> GetClientRating(int ratingId)
    {
        var query = new GetClientRatingQuery(ratingId);
        var result = await mediator.Send(query);

        return result.Match(
            clientRating => Ok(mapper.Map<ClientRatingDto>(clientRating)),
            error => Problem());
    }

    [HttpGet]
    [EnableQuery]
    public async Task<IActionResult> GetClientRatings()
    {
        var query = new GetAllClientRatingsQuery();
        var result = await mediator.Send(query);

        return result.Match(Ok,
            error => Problem());
    }
}