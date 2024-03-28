using AirportManagement.Contracts.Airports;

namespace AirportManagement.Contracts.Airplanes;

public class PlaneStayResponse(
    int id,
    DateTime arrivalDate,
    DateTime departureDate,
    AirportResponse airport,
    AirplaneResponse airplane)
{
    public int Id { get; set; } = id;
    public AirportResponse Airport { get; set; } = airport;
    public AirplaneResponse Airplane { get; set; } = airplane;
    public DateTime ArrivalDate { get; set; } = arrivalDate;
    public DateTime DepartureDate { get; set; } = departureDate;
}