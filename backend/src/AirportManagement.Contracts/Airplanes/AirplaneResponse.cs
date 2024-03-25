using AirportManagement.Contracts.Clients;

namespace AirportManagement.Contracts.Airplanes;

public class AirplaneResponse(
    int id,
    string classification,
    int clientId,
    int maxLoad,
    int passengersCapacity,
    string arriveDate,
    string departureDate,
    bool hasReceivedMaintenance,
    ClientResponse? client = null)
{
    public int Id { get; } = id;
    public string Classification { get; } = classification;
    public int ClientId { get; } = clientId;
    public int MaxLoad { get; } = maxLoad;
    public int PassengersCapacity { get; } = passengersCapacity;
    public string ArriveDate { get; } = arriveDate;
    public string DepartureDate { get; } = departureDate;
    public bool HasReceivedMaintenance { get; } = hasReceivedMaintenance;
    public ClientResponse? Client { get; set; } = client;
}