using Ardalis.SmartEnum;

namespace AirportManagement.Domain.Clients;

public class ClientType(string name, int value) : SmartEnum<ClientType>(name, value)
{
    public static readonly ClientType Company = new(nameof(Company), 0);

    public static readonly ClientType PlaneOwner = new(nameof(PlaneOwner), 1);

    public static readonly ClientType Vip = new(nameof(Vip), 2);

    public static readonly ClientType NormalClient = new(nameof(NormalClient), 3);
}