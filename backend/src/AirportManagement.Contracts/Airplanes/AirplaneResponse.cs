using AirportManagement.Contracts.Clients;

namespace AirportManagement.Contracts.Airplanes;

public class AirplaneResponse(
    int id,
    string classification,
    string planePlate,
    int clientId,
    int maxLoad,
    int passengersCapacity,
    int crewMembers,
    bool hasReceivedMaintenance,
    ClientResponse? client = null)
{
    public int Id { get; } = id;
    public string Classification { get; } = classification;
    public string PlanePlate { get; } = planePlate;
    public int ClientId { get; } = clientId;
    public int MaxLoad { get; } = maxLoad;
    public int PassengersCapacity { get; } = passengersCapacity;
    public int CrewMembers { get; } = crewMembers;
    public bool HasReceivedMaintenance { get; } = hasReceivedMaintenance;
    public ClientResponse? Client { get; set; } = client;
}