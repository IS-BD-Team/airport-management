using System.Reflection;
using AirportManagement.Application.Common.Interfaces;
using AirportManagement.Domain.Airplane;
using AirportManagement.Domain.Airports;
using AirportManagement.Domain.Clients;
using AirportManagement.Domain.Entities;
using AirportManagement.Domain.Facility;
using AirportManagement.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Infrastructure.Common.Persistence;

public class AirportManagementDbContext(DbContextOptions<AirportManagementDbContext> options)
    : DbContext(options), IUnitOfWork
{
    public DbSet<Airport> Airports { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Client> Clients { get; set; } = null!;

    public DbSet<Airplane> Airplanes { get; set; } = null!;

    public DbSet<Service> Services { get; set; } = null!;

    public DbSet<Facility> Facilities { get; set; } = null!;

    public DbSet<ClientRating> ClientRatings { get; set; } = null!;

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