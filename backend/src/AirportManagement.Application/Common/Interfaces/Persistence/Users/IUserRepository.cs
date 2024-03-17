using AirportManagement.Domain.Entities;

namespace AirportManagement.Application.Common.Interfaces.Persistence.Users;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetByEmailAsync(string email);
}