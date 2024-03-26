using AirportManagement.Application.ClientRating.Commands.CreateClientRating;
using AirportManagement.Application.ClientRating.Commands.DeleteClientRating;
using AirportManagement.Application.ClientRating.Commands.UpdateClientRating;
using AirportManagement.Application.ClientRating.Queries.GetAllClientRatings;
using AirportManagement.Application.ClientRating.Queries.GetClientRating;
using AirportManagement.Contracts.ClientRating;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ClientRatingsController(ISender mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateClientRating(ClientRatingRequest request)
    {
        var command = new CreateClientRatingCommand(request.Rating, request.ClientId, request.ServiceId);
        var result = await mediator.Send(command);

        return result.Match(
            clientRating =>
                Ok(new ClientRatingResponse(clientRating.Id, clientRating.ClientId, clientRating.ServiceId,
                    clientRating.Rating)),
            error => Problem());
    }

    [HttpDelete("ratingId")]
    public async Task<IActionResult> DeleteClientRating(int ratingId)
    {
        var command = new DeleteClientRatingCommand(ratingId);
        var result = await mediator.Send(command);

        return result.Match(
            clientRating =>
                Ok(new ClientRatingResponse(clientRating.Id, clientRating.ClientId, clientRating.ServiceId,
                    clientRating.Rating)),
            error => Problem());
    }

    [HttpPut("{ratingId}")]
    public async Task<IActionResult> UpdateClientRating(int ratingId, ClientRatingRequest request)
    {
        var command = new UpdateClientRatingCommand(ratingId, request.Rating);
        var result = await mediator.Send(command);

        return result.Match(
            clientRating =>
                Ok(new ClientRatingResponse(clientRating.Id
                    , clientRating.ClientId, clientRating.ServiceId, clientRating.Rating)),
            error => Problem());
    }

    [HttpGet("{ratingId}")]
    public async Task<IActionResult> GetClientRating(int ratingId)
    {
        var query = new GetClientRatingQuery(ratingId);
        var result = await mediator.Send(query);

        return result.Match(
            clientRating =>
                Ok(new ClientRatingResponse(clientRating.Id, clientRating.ClientId, clientRating.ServiceId,
                    clientRating.Rating)),
            error => Problem());
    }

    [HttpGet]
    public async Task<IActionResult> GetClientRatings()
    {
        var query = new GetAllClientRatingsQuery();
        var result = await mediator.Send(query);

        return result.Match(
            clientRatings =>
                Ok(clientRatings.Select(cr => new ClientRatingResponse(cr.Id, cr.ClientId, cr.ServiceId, cr.Rating))
                    .ToList()),
            error => Problem());
    }
}