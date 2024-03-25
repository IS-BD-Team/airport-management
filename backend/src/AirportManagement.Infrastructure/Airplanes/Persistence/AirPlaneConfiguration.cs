using AirportManagement.Domain.Airplane;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportManagement.Infrastructure.Airplanes.Persistence;

public class AirPlaneConfiguration : IEntityTypeConfiguration<Airplane>
{
    public void Configure(EntityTypeBuilder<Airplane> builder)
    {
        builder.HasKey(plane => plane.Id);

        builder.HasIndex(plane => plane.Id);

        builder.Property(plane => plane.Classification).IsRequired();
        builder.Property(plane => plane.ClientId).IsRequired();
        builder.Property(plane => plane.MaxLoad).IsRequired();
        builder.Property(plane => plane.ArriveDate)
            .HasConversion(
                offset => offset.ToString("F"),
                s => DateTimeOffset.Parse(s))
            .IsRequired();

        builder.Property(plane => plane.DepartureDate)
            .HasConversion(
                offset => offset.ToString("F"),
                s => DateTimeOffset.Parse(s))
            .IsRequired();

        builder.Property(plane => plane.DepartureDate).IsRequired();

        builder.HasMany(plane => plane.Services)
            .WithOne()
            .HasForeignKey(service => service.FacilityId)
            .IsRequired();
    }
}