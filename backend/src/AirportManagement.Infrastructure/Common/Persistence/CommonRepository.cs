using AirportManagement.Application.Common.Interfaces.Persistence;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Infrastructure.Common.Persistence;

public class CommonRepository<T>(AirportManagementDbContext context) : IRepository<T> where T : class
{
    public async Task<Success> AddAsync(T input)
    {
        await context.Set<T>().AddAsync(input);
        return new Success();
    }

    public async Task<Success> DeleteAsync(int id)
    {
        var aux = await GetByIdAsync(id);
        if (aux is null) throw new Exception("Not found");
        context.Set<T>().Remove(aux);
        return new Success();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        var entity = await context.Set<T>().FindAsync(id);
        if (entity is null) throw new Exception("Not Found");
        return entity;
    }

    public Task<T?> UpdateAsync(int id, T input)
    {
        var entity = GetByIdAsync(id);
        return entity;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }
}