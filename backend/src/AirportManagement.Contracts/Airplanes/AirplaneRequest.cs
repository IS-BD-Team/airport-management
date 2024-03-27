namespace AirportManagement.Contracts.Airplanes;

public record AirplaneRequest(
    string Classification,
    int ClientId,
    int MaxLoad,
    int PassengersCapacity,
    int CrewMembers
);