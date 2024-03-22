namespace AirportManagement.Contracts.Clients;

public record CreateClientRequest(
    string Name,
    string Ci,
    string Country,
    string ArrivalRole,
    string ClientType);