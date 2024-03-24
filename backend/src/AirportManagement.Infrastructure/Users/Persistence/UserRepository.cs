using AirportManagement.Application.Common.Interfaces.Persistence.Users;
using AirportManagement.Domain.Entities;
using AirportManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Infrastructure.Users.Persistence;

public class UserRepository(AirportManagementDbContext dbContext) : IUserRepository
{
    public async Task AddAsync(User user)
    {
        await dbContext.Users.AddAsync(user);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await dbContext.Users.Where(user => user.Email == email).FirstOrDefaultAsync();
    }

    public async Task<User?> GetByIdAsync(Guid userId)
    {
        return await dbContext.Users.FindAsync(userId);
    }
}