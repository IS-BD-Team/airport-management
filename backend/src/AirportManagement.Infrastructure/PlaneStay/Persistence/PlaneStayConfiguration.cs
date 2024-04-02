using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportManagement.Infrastructure.PlaneStay.Persistence;

public class PlaneStayConfiguration : IEntityTypeConfiguration<Domain.PlaneStay.PlaneStay>
{
    public void Configure(EntityTypeBuilder<Domain.PlaneStay.PlaneStay> builder)
    {
        builder.HasKey(stay => stay.Id);

        builder.Property(stay => stay.AirplaneId).IsRequired();
        builder.Property(stay => stay.AirportId).IsRequired();
        builder.Property(stay => stay.ArrivalDate).IsRequired();
        builder.Property(stay => stay.DepartureDate).IsRequired()
            .HasConversion(
                time => time.ToString("F"),
                s => DateTime.Parse(s)
            );
        builder.Property(stay => stay.ArrivalDate).IsRequired()
            .HasConversion(
                time => time.ToString("F"),
                s => DateTime.Parse(s)
            );
    }
}