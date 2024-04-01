using AirportManagement.Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportManagement.Infrastructure.Clients.Persistence;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(client => client.Id);
        builder.HasIndex(client => client.Id);

        // builder.Property(client => client.ArrivalRole)
        //     .HasConversion(
        //         role => role.Value,
        //         value => ArrivalRole.FromValue(value));
        //
        // builder.Property(client => client.ClientType)
        //     .HasConversion(
        //         type => type.Value,
        //         value => ClientType.FromValue(value));
    }
}