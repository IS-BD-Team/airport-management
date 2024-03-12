
using System.ComponentModel.DataAnnotations;

namespace AirportManagement.Domain.Airports;

public class Airport(string name, string address)
{
    [Key]
    public int Id { get; private set; }
    
    [Required]
    public string Name { get; private set; } = name;

    [Required]
    public string Address { get; private set; } = address;
}