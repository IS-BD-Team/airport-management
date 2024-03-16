using System.Reflection;
using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Domain.Airports;
using AirportManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Infrastructure.Common.Persistence;

public class AirportManagementDbContext(DbContextOptions<AirportManagementDbContext> options)
    : DbContext(options), IUnitOfWork
{
    public DbSet<Airport> Airports { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    public async Task CommitChangesAsync()
    {
        await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}