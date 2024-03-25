using AirportManagement.Application.Clients.Commands.CreateClient;
using AirportManagement.Application.Clients.Commands.DeleteClient;
using AirportManagement.Application.Clients.Commands.UpdateClient;
using AirportManagement.Application.Clients.Queries.GetClient;
using AirportManagement.Contracts.Clients;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ClientsController(ISender mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateClient(ClientRequest request)
    {
        var command = new CreateClientCommand(
            request.Name, request.Ci,
            request.Country, request.ArrivalRole,
            request.ClientType);

        var createClientResult = await mediator.Send(command);

        return createClientResult.MatchFirst(
            client => Ok(new ClientResponse(
                client.Id, client.Name, client.Ci,
                client.Country,
                client.ArrivalRole.ToString(),
                client.ClientType.ToString())),
            _ => Problem());
    }

    [HttpGet]
    public async Task<IActionResult> GetClients()
    {
        var query = new GetClientsQuery();

        var getClientsResult = await mediator.Send(query);

        return getClientsResult.MatchFirst(
            clients => Ok(clients.Select(client => new ClientResponse(
                client.Id,
                client.Name,
                client.Ci,
                client.Country,
                client.ArrivalRole.ToString(),
                client.ClientType.ToString()
            )).ToList()),
            error => Problem(error.Code, statusCode: error.NumericType));
    }

    [HttpGet("{clientId:int}")]
    public async Task<IActionResult> GetClient(int clientId)
    {
        var query = new GetClientQuery(clientId);
        var getClientResult = await mediator.Send(query);
        return getClientResult.MatchFirst(
            client => Ok(new ClientResponse(client.Id, client.Name, client.Ci, client.Country,
                client.ArrivalRole.ToString(),
                client.ClientType.ToString())), error => Problem(error.Code, statusCode: error.NumericType));
    }

    [HttpPut("{clientId:int}")]
    public async Task<IActionResult> UpdateClient(int clientId, ClientRequest request)
    {
        var command = new UpdateClientCommand(clientId, request.Name, request.Ci, request.Country, request.ArrivalRole,
            request.ClientType);

        var updateClientResult = await mediator.Send(command);

        return updateClientResult.MatchFirst(
            client => Ok(new ClientResponse(
                client.Id, client.Name, client.Ci, client.Country,
                client.ArrivalRole.ToString(),
                client.ClientType.ToString())), error => Problem(error.Code, statusCode: error.NumericType));
    }

    [HttpDelete("{clientId:int}")]
    public async Task<IActionResult> DeleteClient(int clientId)
    {
        var command = new DeleteClientCommand(clientId);

        var deleteClientResult = await mediator.Send(command);

        return deleteClientResult.MatchFirst(
            _ => Ok(StatusCode(200)), error => Problem(error.Code, statusCode: error.NumericType));
    }
}