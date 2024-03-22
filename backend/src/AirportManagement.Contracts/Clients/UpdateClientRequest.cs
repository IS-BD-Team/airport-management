namespace AirportManagement.Contracts.Clients;

public record UpdateClientRequest(
    string Name,
    string Ci,
    string Country,
    string ArrivalRole,
    string ClientType);