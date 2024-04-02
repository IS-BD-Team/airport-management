namespace AirportManagement.Application.DTO;

public class PlaneStayDto
{
    public int Id { get; set; }
    public int AirportId { get; set; }
    public int AirplaneId { get; set; }
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
}