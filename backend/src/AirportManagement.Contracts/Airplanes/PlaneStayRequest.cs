namespace AirportManagement.Contracts.Airplanes;

public record PlaneStayRequest(int AirplaneId, int AirportId, DateTime ArrivalDate, DateTime DepartureDate);