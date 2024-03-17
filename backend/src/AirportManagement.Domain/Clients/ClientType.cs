using Ardalis.SmartEnum;

namespace AirportManagement.Domain.Clients;

public class ClientType(string name,int value):SmartEnum<ClientType>(name,value)
{
    public static readonly ClientType Admin = new(nameof(Admin),0);
    
    public static readonly ClientType SuperAdmin = new(nameof(SuperAdmin),1);
    
}