namespace AirportManagement.Contracts.Clients;

public record ClientResponse(
    int ClientId,
    string Name,
    string Ci,
    string Country,
    string ArrivalRole,
    string ClientType);