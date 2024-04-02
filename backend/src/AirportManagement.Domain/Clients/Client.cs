using System.ComponentModel.DataAnnotations;

namespace AirportManagement.Domain.Clients;

public class Client
{
    public Client(string name, string ci, string country, string arrivalRole, string clientType)
    {
        Name = name;
        Ci = ci;
        Country = country;
        ArrivalRoleEnum = ArrivalRoleEnum.FromName(arrivalRole);
        ClientTypeEnum = ClientTypeEnum.FromName(clientType);
    }

    public Client()
    {
    }

    private ArrivalRoleEnum ArrivalRoleEnum { get; set; } = null!;
    private ClientTypeEnum ClientTypeEnum { get; set; } = null!;
    [Key] public int Id { get; init; }

    [Required] public string Name { get; set; }

    [Required] public string Ci { get; set; }

    [Required] public string Country { get; set; }

    [Required]
    public string ClientType
    {
        get => ClientTypeEnum.Name;
        set => ClientTypeEnum = ClientTypeEnum.FromName(value);
    }

    [Required]
    public string ArrivalRole
    {
        get => ArrivalRoleEnum.Name;
        set => ArrivalRoleEnum = ArrivalRoleEnum.FromName(value);
    }

    public ICollection<Airplane.Airplane>? Airplanes { get; set; }
}