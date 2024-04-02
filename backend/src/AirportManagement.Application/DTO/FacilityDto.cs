namespace AirportManagement.Application.DTO;

public class FacilityDto
{
    public int Id { get; init; }
    public string Name { get; set; } = default!;
    public string Location { get; set; } = default!;
    public string Type { get; set; }
    public int AirportId { get; set; } = default!;
}