using AirportManagement.Application.Common.Interfaces.Persistence.Users;
using AirportManagement.Domain.Entities;
using AirportManagement.Infrastructure.Common.Persistence;

namespace AirportManagement.Infrastructure.Users.Persistence;

public class UserRepository(AirportManagementDbContext dbContext) : IUserRepository
{
    public async Task AddAsync(User user)
    {
        await dbContext.Users.AddAsync(user);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await dbContext.Users.FindAsync(email);
    }
}