using AirportManagement.Domain.Facility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportManagement.Infrastructure.Facilities.Persistence;

public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
{
    public void Configure(EntityTypeBuilder<Facility> builder)
    {
        builder.HasKey(facility => facility.Id);
        builder.HasIndex(facility => facility.Id);
    }
}