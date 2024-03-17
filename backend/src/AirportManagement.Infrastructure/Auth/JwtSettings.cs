namespace AirportManagement.Infrastructure.Auth;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public int ExpireMinutes { get; init; }
    public string Secret { get; init; } = null!;
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
}