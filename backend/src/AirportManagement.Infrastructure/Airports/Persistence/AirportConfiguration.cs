using AirportManagement.Domain.Airports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportManagement.Infrastructure.Airports.Persistence;

public class AirportConfiguration : IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.HasKey(airport => airport.Id);

        builder.HasIndex(airport => airport.Id);

        builder.Property(s => s.Id).ValueGeneratedNever();
    }
}