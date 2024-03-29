namespace AirportManagement.Contracts.Airplanes;

public record AirplaneRequest(
    string Classification,
    string PlanePlate,
    int ClientId,
    int MaxLoad,
    int PassengersCapacity,
    int CrewMembers
);