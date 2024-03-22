using Ardalis.SmartEnum;

namespace AirportManagement.Domain.Clients;

public class ArrivalRole(string name, int value) : SmartEnum<ArrivalRole>(name, value)
{
    public static readonly ArrivalRole Passenger = new(nameof(Passenger), 0);
    public static readonly ArrivalRole Captain = new(nameof(Captain), 1);
    public static readonly ArrivalRole OwnerCaptain = new(nameof(OwnerCaptain), 2);
    public static readonly ArrivalRole NormalClient = new(nameof(NormalClient), 3);
}