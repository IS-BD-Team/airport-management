namespace AirportManagement.Contracts.Airplanes;

public record AirplaneResponse(
    int Id,
    string Classification,
    int ClientId,
    int MaxLoad,
    int PassengersCapacity,
    string ArriveDate,
    string DepartureDate,
    bool HasReceivedMaintenance);