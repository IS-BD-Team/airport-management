using Ardalis.SmartEnum;

namespace AirportManagement.Domain.Clients;

public class ClientTypeEnum(string name, int value) : SmartEnum<ClientTypeEnum>(name, value)
{
    public static readonly ClientTypeEnum Company = new(nameof(Company), 0);

    public static readonly ClientTypeEnum PlaneOwner = new(nameof(PlaneOwner), 1);

    public static readonly ClientTypeEnum Vip = new(nameof(Vip), 2);

    public static readonly ClientTypeEnum NormalClient = new(nameof(NormalClient), 3);
}