using AirportManagement.Domain.Airplane;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportManagement.Infrastructure.Airplanes.Persistence;

public class AirplaneConfiguration : IEntityTypeConfiguration<Airplane>
{
    public void Configure(EntityTypeBuilder<Airplane> builder)
    {
        builder.HasKey(plane => plane.Id);

        builder.HasIndex(plane => plane.Id);

        builder.Property(plane => plane.Classification).IsRequired();
        builder.Property(plane => plane.ClientId).IsRequired();
        builder.Property(plane => plane.MaxLoad).IsRequired();
    }
}