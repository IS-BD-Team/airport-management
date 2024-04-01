namespace AirportManagement.Application.DTO;

public class ClientDto
{
    public int Id { get; init; }
    public string Name { get; set; } = default!;
    public string Ci { get; set; } = default!;
    public string Country { get; set; } = default!;
    public string ClientType { get; set; }
    public string ArrivalRole { get; set; }
}