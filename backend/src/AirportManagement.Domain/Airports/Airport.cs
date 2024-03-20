using System.ComponentModel.DataAnnotations;

namespace AirportManagement.Domain.Airports;

public class Airport(string name, string address)
{
    [Key] public int Id { get; set; }

    [Required] public string Name { get; set; } = name;

    [Required] public string Address { get; set; } = address;
}