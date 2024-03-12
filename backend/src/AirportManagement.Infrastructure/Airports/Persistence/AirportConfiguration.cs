using AirportManagement.Domain.Airports;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportManagement.Infrastructure.Airports.Persistence;

public class AirportConfiguration
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedNever();
    }
}