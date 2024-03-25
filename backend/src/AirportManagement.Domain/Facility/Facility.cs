using AirportManagement.Domain.Services;

namespace AirportManagement.Domain.Facility;

public class Facility(string? name, string type, string location)
{
    public int Id { get; set; }
    public string? Name { get; set; } = name;
    public string Type { get; set; } = type;
    public string Location { get; set; } = location;

    private ICollection<Service>? Services { get; set; }
}