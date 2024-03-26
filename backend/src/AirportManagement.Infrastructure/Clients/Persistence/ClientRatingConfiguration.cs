using AirportManagement.Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportManagement.Infrastructure.Clients.Persistence;

public class ClientRatingConfiguration : IEntityTypeConfiguration<ClientRating>
{
    public void Configure(EntityTypeBuilder<ClientRating> builder)
    {
        builder.HasKey(rating => rating.Id);
    }
}