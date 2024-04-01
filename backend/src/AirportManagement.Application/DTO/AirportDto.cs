namespace AirportManagement.Application.DTO;

public class AirportDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string GeographicLocation { get; set; } = null!;
    public string? PhotoUrl { get; set; }
    public ICollection<FacilityDto>? Facilities { get; set; }
}