namespace AirportManagement.Contracts.Clients;

public class ClientResponse(
    int clientId,
    string name,
    string ci,
    string country,
    string arrivalRole,
    string clientType)
{
    public int ClientId { get; } = clientId;
    public string Name { get; } = name;
    public string Ci { get; } = ci;
    public string Country { get; } = country;
    public string ArrivalRole { get; } = arrivalRole;
    public string ClientType { get; } = clientType;
}