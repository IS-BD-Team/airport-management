using AirportManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportManagement.Infrastructure.Users.Persistence;

public class UserConfiguration
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Email);
        builder.Property(user => user.Email).ValueGeneratedNever();
    }
}