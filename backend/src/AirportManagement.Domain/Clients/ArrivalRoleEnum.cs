using Ardalis.SmartEnum;

namespace AirportManagement.Domain.Clients;

public class ArrivalRoleEnum(string name, int value) : SmartEnum<ArrivalRoleEnum>(name, value)
{
    public static readonly ArrivalRoleEnum Passenger = new(nameof(Passenger), 0);
    public static readonly ArrivalRoleEnum Captain = new(nameof(Captain), 1);
    public static readonly ArrivalRoleEnum OwnerCaptain = new(nameof(OwnerCaptain), 2);
    public static readonly ArrivalRoleEnum NormalClient = new(nameof(NormalClient), 3);
}