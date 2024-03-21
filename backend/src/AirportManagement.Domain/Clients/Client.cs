using System.ComponentModel.DataAnnotations;
using AirportManagement.Domain.Planes;

namespace AirportManagement.Domain.Clients;

public class Client(string name, string ci, string country, ArrivalRole arrivalRole, ClientType clientType)
{
    [Key] public int Id { get; set; }

    [Required] public string Name { get; set; } = name;

    [Required] public string Ci { get; set; } = ci;

    [Required] public string Country { get; set; } = country;

    [Required] public ClientType ClientType { get; set; } = clientType;

    [Required] public ArrivalRole ArrivalRole { get; set; } = arrivalRole;

    public ICollection<Plane>? Planes { get; set; }
}