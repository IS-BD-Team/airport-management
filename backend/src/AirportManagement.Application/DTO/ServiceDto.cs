namespace AirportManagement.Application.DTO;

public class ServiceDto
{
    public int Id { get; init; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public FacilityDto Facility { get; set; }
}