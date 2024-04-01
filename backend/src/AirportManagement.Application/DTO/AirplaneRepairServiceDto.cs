namespace AirportManagement.Application.DTO;

public class AirplaneRepairServiceDto
{
    public int Id { get; init; }

    public decimal ElapsedHours { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
    public AirplaneDto Plane { get; set; }
    public RepairServiceDto RepairService { get; set; }
}