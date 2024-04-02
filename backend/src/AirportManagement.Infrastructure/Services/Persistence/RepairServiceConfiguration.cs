using AirportManagement.Domain.RepairServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportManagement.Infrastructure.Services.Persistence;

public class RepairServiceConfiguration : IEntityTypeConfiguration<RepairService>
{
    public void Configure(EntityTypeBuilder<RepairService> builder)
    {
    }
}