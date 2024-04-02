using AirportManagement.Application.Clients.Commands.CreateClient;
using AirportManagement.Application.Clients.Commands.DeleteClient;
using AirportManagement.Application.Clients.Commands.UpdateClient;
using AirportManagement.Application.Clients.Queries.GetAllClients;
using AirportManagement.Application.Clients.Queries.GetClient;
using AirportManagement.Application.DTO;
using AirportManagement.Contracts.Clients;
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
public class ClientsController(ISender mediator, IMapper mapper) : ODataController
{
    [HttpPost]
    public async Task<IActionResult> CreateClient(ClientRequest request)
    {
        var command = new CreateClientCommand(
            request.Name, request.Ci,
            request.Country,
            request.ClientType);

        var createClientResult = await mediator.Send(command);

        return createClientResult.MatchFirst(
            client => Ok(mapper.Map<ClientDto>(client)),
            _ => Problem());
    }

    [HttpGet]
    [EnableQuery]
    public async Task<IActionResult> GetClients()
    {
        var query = new GetAllClientsQuery();

        var getClientsResult = await mediator.Send(query);

        return getClientsResult.MatchFirst(
            Ok,
            error => Problem(error.Code, statusCode: error.NumericType));
    }

    [HttpGet("{clientId:int}")]
    public async Task<IActionResult> GetClient(int clientId)
    {
        var query = new GetClientQuery(clientId);
        var getClientResult = await mediator.Send(query);
        return getClientResult.MatchFirst(
            client => Ok(mapper.Map<ClientDto>(client)),
            error => Problem(error.Code, statusCode: error.NumericType));
    }

    [HttpPut("{clientId:int}")]
    public async Task<IActionResult> UpdateClient(int clientId, ClientRequest request)
    {
        var command = new UpdateClientCommand(clientId, request.Name, request.Ci, request.Country, request.ClientType);

        var updateClientResult = await mediator.Send(command);

        return updateClientResult.MatchFirst(
            client => Ok(mapper.Map<ClientDto>(client)),
            error => Problem(error.Code, statusCode: error.NumericType));
    }

    [HttpDelete("{clientId:int}")]
    public async Task<IActionResult> DeleteClient(int clientId)
    {
        var command = new DeleteClientCommand(clientId);

        var deleteClientResult = await mediator.Send(command);

        return deleteClientResult.MatchFirst(
            _ => Ok(StatusCode(204)),
            error => Problem(error.Code, statusCode: error.NumericType));
    }
}