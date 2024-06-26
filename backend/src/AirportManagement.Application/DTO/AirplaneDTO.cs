namespace AirportManagement.Application.DTO;

public class AirplaneDto
{
    public int Id { get; init; }
    public string Classification { get; set; } = default!;
    public string PlanePlate { get; set; } = default!;
    public int MaxLoad { get; set; }
    public int PassengersCapacity { get; set; }
    public int CrewMembers { get; set; }
    public int ClientId { get; set; }
}