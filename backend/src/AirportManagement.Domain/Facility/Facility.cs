using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportManagement.Domain.Airports;
using AirportManagement.Domain.Services;

namespace AirportManagement.Domain.Facility;

public class Facility(string? name, string type, string location, int airportId)
{
    [Required] public int Id { get; set; }
    public string? Name { get; set; } = name;
    [Required] public string Type { get; set; } = type;
    [Required] public string Location { get; set; } = location;

    [Required] public int AirportId { get; set; } = airportId;
    [ForeignKey(nameof(AirportId))] public Airport Airport { get; set; } = null!;

    public ICollection<Service>? Services { get; set; }
}