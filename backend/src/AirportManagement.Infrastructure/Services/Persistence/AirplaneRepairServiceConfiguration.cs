using AirportManagement.Domain.AirplaneRepairService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportManagement.Infrastructure.Services.Persistence;

public class AirplaneRepairServiceConfiguration : IEntityTypeConfiguration<AirplaneRepairService>
{
    public void Configure(EntityTypeBuilder<AirplaneRepairService> builder)
    {
        builder.HasKey(service => service.Id);
        builder.Property(service => service.StartDate)
            .HasConversion(time => time.ToString("F"), s => DateTime.Parse(s));
        builder.Property(service => service.EndDate)
            .HasConversion(time => time.ToString("F"), s => DateTime.Parse(s));
    }
}