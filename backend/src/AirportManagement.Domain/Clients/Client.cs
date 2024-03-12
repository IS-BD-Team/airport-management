using System.ComponentModel.DataAnnotations;

namespace AirportManagement.Domain.Clients;

public class Client(string name, ClientType clientType, string ci, string country)
{
    
    [Key]
    public int Id { get; set; }
  
    [Required]
    public string Name { get; private set; } = name;

    [Required]
    public string Ci { get; private set; } = ci;

    [Required]
    public string Country { get; private set; } = country;

    [Required]
    public ClientType ClientType { get; private set; } = clientType;
}