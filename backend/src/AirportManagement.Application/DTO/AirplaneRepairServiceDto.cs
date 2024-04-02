namespace AirportManagement.Application.DTO;

public class AirplaneRepairServiceDto
{
    public int Id { get; init; }

    public decimal ElapsedHours { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int AirplaneId { get; set; }
    public int RepairServiceId { get; set; }
}