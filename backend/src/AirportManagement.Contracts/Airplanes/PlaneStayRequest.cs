namespace AirportManagement.Contracts.Airplanes;

public record PlaneStayRequest(int AirplaneId, int AirportId, int Rating, DateTime ArrivalDate, DateTime DepartureDate);