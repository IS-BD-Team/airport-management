using System.ComponentModel.DataAnnotations;

namespace AirportManagement.Domain.Airports;

public class Airport(string name, string address, string geographicLocation, string? photoUrl = null)
{
    [Key] public int Id { get; init; }

    [Required] public string Name { get; set; } = name;
    [Required] public string Address { get; set; } = address;

    [Required] public string GeographicLocation { get; set; } = geographicLocation;

    public string? PhotoUrl { get; set; } = photoUrl;
}