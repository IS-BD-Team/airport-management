namespace AirportManagement.Contracts.Clients;

public record ClientRequest(
    string Name,
    string Ci,
    string Country,
    string ClientType);