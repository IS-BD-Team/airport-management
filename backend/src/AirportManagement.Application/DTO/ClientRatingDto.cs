namespace AirportManagement.Application.DTO;

public class ClientRatingDto
{
    public int Id { get; init; }
    public int PlaneStayId { get; init; }
    public int ServiceId { get; init; }
    public int Rating { get; set; }
}