namespace AirportManagement.Domain.Facility;

public class Facility(int id, string name, string type, string location)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Type { get; set; } = type;
    public string Location { get; set; } = location;
}